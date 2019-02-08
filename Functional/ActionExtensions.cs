using System;

namespace Functional
{
    public static class ActionExtensions
    {
        #region Composition
        public static Action<T> Before<T, TResult>(this Action<TResult> action, Func<T, TResult> func)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return (T arg) => action(func(arg));
        }
        #endregion

        #region Currying
        public static Func<T1, Action<T2>> Curry<T1, T2, TResult>(this Action<T1, T2> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            return (T1 arg1) => (T2 arg2) => action(arg1, arg2);
        }

        public static Func<T1, Func<T2, Action<T3>>> Curry<T1, T2, T3, TResult>(this Action<T1, T2, T3> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            return (T1 arg1) => (T2 arg2) => (T3 arg3) => action(arg1, arg2, arg3);
        }

        public static Func<T1, Func<T2, Func<T3, Action<T4>>>> Curry<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            return (T1 arg1) => (T2 arg2) => (T3 arg3) => (T4 arg4) => action(arg1, arg2, arg3, arg4);
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4, Action<T5>>>>> Curry<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            return (T1 arg1) => (T2 arg2) => (T3 arg3) => (T4 arg4) => (T5 arg5) => action(arg1, arg2, arg3, arg4, arg5);
        }
        #endregion

        public static Action<T1, T2> Uncurry<T1, T2>(this Func<T1, Action<T2>> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            return (T1 arg1, T2 arg2) => action(arg1)(arg2);
        }

        public static Action<T1, T2, T3> Uncurry<T1, T2, T3>(this Func<T1, Func<T2, Action<T3>>> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            return (T1 arg1, T2 arg2, T3 arg3) => action(arg1)(arg2)(arg3);
        }

        public static Action<T1, T2, T3, T4> Uncurry<T1, T2, T3, T4>(this Func<T1, Func<T2, Func<T3, Action<T4>>>> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            return (T1 arg1, T2 arg2, T3 arg3, T4 arg4) => action(arg1)(arg2)(arg3)(arg4);
        }

        public static Action<T1, T2, T3, T4, T5> Uncurry<T1, T2, T3, T4, T5>(this Func<T1, Func<T2, Func<T3, Func<T4, Action<T5>>>>> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            return (T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => action(arg1)(arg2)(arg3)(arg4)(arg5);
        }
    }
}
