using System;

namespace Functional
{
    public struct Option<T>
    {
        readonly T _value;
        public readonly bool IsSome;

        public Option(T value)
        {
            _value = value;
            IsSome = true;
        }

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

        public Option<TResult> Map<TResult>(Func<T, TResult> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return IsSome ? new Option<TResult>(func(_value)) : new Option<TResult>();
        }

        public void Iter(Action<T> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            if (IsSome) action(_value);
        }

        public T GetOrElse(T defaultValue) => IsSome ? _value : defaultValue;

        /// <summary>
        /// Just Map with another name to enable query syntax.
        /// </summary>
        public Option<TResult> Select<TResult>(Func<T, TResult> selector) => Map(selector);
    }
}
