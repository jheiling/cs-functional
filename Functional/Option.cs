using System;
using System.Collections;
using System.Collections.Generic;

namespace Functional
{
    public struct Option<T> : IEnumerable<T>
    {
        readonly T _value;
        public readonly bool IsSome;

        public Option(T value)
        {
            _value = value;
            IsSome = true;
        }

        public T GetOrElse(T defaultValue) => IsSome ? _value : defaultValue;

        public TResult Match<TResult>(Func<T, TResult> funcSome, Func<TResult> funcNone)
        {
#if DEBUG
            if (funcSome == null) throw new ArgumentNullException(nameof(funcSome));
            if (funcNone == null) throw new ArgumentNullException(nameof(funcNone));
#endif
            return IsSome ? funcSome(_value) : funcNone();
        }

        public void Match(Action<T> actionSome, Action actionNone)
        {
#if DEBUG
            if (actionSome == null) throw new ArgumentNullException(nameof(actionSome));
            if (actionNone == null) throw new ArgumentNullException(nameof(actionNone));
#endif
            if (IsSome) actionSome(_value);
            else actionNone();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (IsSome) yield return _value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (IsSome) yield return _value;
        }

        public Option<TResult> Select<TResult>(Func<T, TResult> selector)
        {
#if DEBUG
            if (selector == null) throw new ArgumentNullException(nameof(selector));
#endif
            return IsSome ? new Option<TResult>(selector(_value)) : new Option<TResult>();
        }

        public Option<T> Where(Func<T, bool> predicate)
        {
#if DEBUG
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
#endif
            return IsSome ? (predicate(_value) ? this : new Option<T>()) : this;
        }

        public void ForEach(Action<T> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            if (IsSome) action(_value);
        }

        public Option<TResult> Bind<TResult>(Func<T, Option<TResult>> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return IsSome ? func(_value) : new Option<TResult>();
        }
    }
}
