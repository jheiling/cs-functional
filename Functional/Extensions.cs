using System;

namespace Functional
{
    public static class Extensions
    {
        public static T Id<T>(this T value) => value;

        #region Piping
        public static TResult Apply<T, TResult>(this T value, in Func<T, TResult> func)
        {
#if DEBUG
            if (func == null) throw new ArgumentNullException(nameof(func));
#endif
            return func(value);
        }

        public static void Apply<T>(this T value, in Action<T> action)
        {
#if DEBUG
            if (action == null) throw new ArgumentNullException(nameof(action));
#endif
            action(value);
        }
        #endregion
    }
}
