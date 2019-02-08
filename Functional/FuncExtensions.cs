using System;

namespace Functional
{
    public static class FuncExtensions
    {
        #region Composition
        public static Func<T, TResult2> Then<T, TResult1, TResult2>(this Func<T, TResult1> func1, Func<TResult1, TResult2> func2)
        {
#if DEBUG
            if (func1 == null) throw new ArgumentNullException(nameof(func1));
            if (func2 == null) throw new ArgumentNullException(nameof(func2));
#endif
            return (T arg) => func2(func1(arg));
        }

        public static Action<T> Then<T, TResult>(this Func<T, TResult> func, Action<TResult> action)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            return (T arg) => action(func(arg));
        }

        public static Func<T, TResult2> Before<T, TResult1, TResult2>(this Func<TResult1, TResult2> func1, Func<T, TResult1> func2)
        {
#if DEBUG
            if (func1 == null) throw new ArgumentNullException(nameof(func1));
            if (func2 == null) throw new ArgumentNullException(nameof(func2));
#endif
            return (T arg) => func1(func2(arg));
        }
        #endregion

        #region Currying
        public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return (T1 arg1) => (T2 arg2) => func(arg1, arg2);
        }

        public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return (T1 arg1) => (T2 arg2) => (T3 arg3) => func(arg1, arg2, arg3);
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return (T1 arg1) => (T2 arg2) => (T3 arg3) => (T4 arg4) => func(arg1, arg2, arg3, arg4);
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> Curry<T1, T2, T3, T4, T5, TResult>(this Func<T1, T2, T3, T4, T5, TResult> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return (T1 arg1) => (T2 arg2) => (T3 arg3) => (T4 arg4) => (T5 arg5) => func(arg1, arg2, arg3, arg4, arg5);
        }

        public static Func<T1, T2, TResult> Uncurry<T1, T2, TResult>(this Func<T1, Func<T2, TResult>> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return (T1 arg1, T2 arg2) => func(arg1)(arg2);
        }

        public static Func<T1, T2, T3, TResult> Uncurry<T1, T2, T3, TResult>(this Func<T1, Func<T2, Func<T3, TResult>>> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return (T1 arg1, T2 arg2, T3 arg3) => func(arg1)(arg2)(arg3);
        }

        public static Func<T1, T2, T3, T4, TResult> Uncurry<T1, T2, T3, T4, TResult>(this Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return (T1 arg1, T2 arg2, T3 arg3, T4 arg4) => func(arg1)(arg2)(arg3)(arg4);
        }

        public static Func<T1, T2, T3, T4, T5, TResult> Uncurry<T1, T2, T3, T4, T5, TResult>(this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return (T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => func(arg1)(arg2)(arg3)(arg4)(arg5);
        }
        #endregion
    }
}
