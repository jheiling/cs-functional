using System;
using System.Collections;
using System.Collections.Generic;

namespace Functional
{
    /// <summary>Contains either a non <see langword="null"/> value of type <typeparamref name="T"/> or nothing.</summary>
    /// <typeparam name="T">The wrapped type.</typeparam>
    public struct Option<T> : IEnumerable<T>
    {
        /// <summary>The wrapped value if <see cref="HasValue"/> is <see langword="true"/>, otherwise the wrapped type's default value.</summary>
        public readonly T Value;

        /// <summary><see langword="true"/> if instantiated with a non <see langword="null"/> value, <see langword="false"/> otherwise.</summary>
        public readonly bool HasValue;

        /// <summary>Constructs an <see cref="Option"/> with the given <paramref name="value"/>.</summary>
        /// <param name="value">The value to wrap.</param>
        public Option(in T value)
        {
#pragma warning disable IDE0041 // Use 'is null' check
            if (ReferenceEquals(value, null))
#pragma warning restore IDE0041 // Use 'is null' check
            {
                Value = default;
                HasValue = false;
            }
            else
            {
                Value = value;
                HasValue = true;
            }
        }

        /// <summary>Gets the wrapped <see cref="Value"/> or a <paramref name="defaultValue"/>.</summary>
        /// <param name="defaultValue">The return value if <see cref="HasValue"/> is <see langword="false"/>.</param>
        /// <returns><see cref="Value"/> if <see cref="HasValue"/> is <see langword="true"/>, <paramref name="defaultValue"/> otherwise.</returns>
        public T GetOrElse(in T defaultValue) => HasValue ? Value : defaultValue;

        /// <summary>Calls <paramref name="funcSome"/> if <see cref="HasValue"/> is <see langword="true"/>, or <paramref name="funcNone"/> otherwise, and returns the result.</summary>
        /// <typeparam name="TResult">The return type.</typeparam>
        /// <param name="funcSome">The function to call if <see cref="HasValue"/> is <see langword="true"/>.</param>
        /// <param name="funcNone">The function to call if <see cref="HasValue"/> is <see langword="false"/>.</param>
        /// <returns>The result of calling <paramref name="funcSome"/> with <see cref="Value"/> if <see cref="HasValue"/> is <see langword="true"/>, the result of <paramref name="funcNone"/> otherwise.</returns>
        public TResult Match<TResult>(in Func<T, TResult> funcSome, in Func<TResult> funcNone)
        {
#if DEBUG
            if (funcSome == null) throw new ArgumentNullException(nameof(funcSome));
            if (funcNone == null) throw new ArgumentNullException(nameof(funcNone));
#endif
            return HasValue ? funcSome(Value) : funcNone();
        }

        /// <summary>Calls <paramref name="actionSome"/> if <see cref="HasValue"/> is <see langword="true"/>, or <paramref name="actionNone"/> otherwise.</summary>
        /// <param name="actionSome">The function to call if <see cref="HasValue"/> is <see langword="true"/>.</param>
        /// <param name="actionNone">The function to call if <see cref="HasValue"/> is <see langword="false"/>.</param>
        public void Match(in Action<T> actionSome, in Action actionNone)
        {
#if DEBUG
            if (actionSome == null) throw new ArgumentNullException(nameof(actionSome));
            if (actionNone == null) throw new ArgumentNullException(nameof(actionNone));
#endif
            if (HasValue) actionSome(Value);
            else actionNone();
        }

        /// <summary>Gets the <see cref="IEnumerator"/> for the <see cref="Option"/>.</summary>
        /// <returns>The <see cref="IEnumerator"/>.</returns>
        public IEnumerator<T> GetEnumerator() { if (HasValue) yield return Value; }

        IEnumerator IEnumerable.GetEnumerator() { if (HasValue) yield return Value; }

        /// <summary>Transforms an <see cref="Option"/> value by using the specified <paramref name="selector"/> function.</summary>
        /// <typeparam name="TResult">The wrapped return type.</typeparam>
        /// <param name="selector">A function to apply to the <see cref="Value"/>.</param>
        /// <returns>An <see cref="Option"/> containing the return value of <paramref name="selector"/> applied to <see cref="Value"/>, or an empty <see cref="Option"/> if <see cref="HasValue"/> is <see langword="false"/>.</returns>
        public Option<TResult> Select<TResult>(in Func<T, TResult> selector)
        {
#if DEBUG
            if (selector == null) throw new ArgumentNullException(nameof(selector));
#endif
            return HasValue ? new Option<TResult>(selector(Value)) : new Option<TResult>();
        }

        /// <summary>Filters an <see cref="Option"/> value by the specified <paramref name="predicate"/>.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>An <see cref="Option"/> value containing the <see cref="Value"/> if the <paramref name="predicate"/> evaluates to <see langword="true"/>, or an empty <see cref="Option"/> otherwise.</returns>
        public Option<T> Where(in Func<T, bool> predicate)
        {
#if DEBUG
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
#endif
            return HasValue ? (predicate(Value) ? this : new Option<T>()) : this;
        }

        /// <summary>Calls the specified <paramref name="action"/> with <see cref="Value"/> if <see cref="HasValue"/> is <see langword="true"/>.</summary>
        /// <param name="action">The action to call.</param>
        public void ForEach(in Action<T> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            if (HasValue) action(Value);
        }

        /// <summary>Calls the specified <paramref name="func"/> with <see cref="Value"/> if <see cref="HasValue"/> is <see langword="true"/>.</summary>
        /// <typeparam name="TResult">The wrapped return type.</typeparam>
        /// <param name="func">The function to call with <see cref="Value"/>.</param>
        /// <returns>The result of calling <paramref name="func"/> with <see cref="Value"/> if <see cref="HasValue"/> is <see langword="true"/>, or an empty <see cref="Option"/> otherwise.</returns>
        public Option<TResult> Bind<TResult>(in Func<T, Option<TResult>> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return HasValue ? func(Value) : new Option<TResult>();
        }
    }
}
