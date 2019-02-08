using System;

namespace Functional
{
    public class Choice<T1, T2>
    {
        public readonly int Case;
        public readonly object Value;

        public Choice(T1 value)
        {
            Case = 1;
            Value = value;
        }

        public Choice(T2 value)
        {
            Case = 2;
            Value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1,
            Func<T2, TResult> func2)
        {
#if DEBUG
            if (func1 == null) throw new ArgumentNullException(nameof(func1));
            if (func2 == null) throw new ArgumentNullException(nameof(func2));
#endif
            return
                Case == 1 ? func1((T1)Value)
                : func2((T2)Value);
        }

        public void Match(
            Action<T1> action1,
            Action<T2> action2)
        {
#if DEBUG
            if (action1 == null) throw new ArgumentNullException(nameof(action1));
            if (action2 == null) throw new ArgumentNullException(nameof(action2));
#endif
            if (Case == 1) action1((T1)Value);
            else action2((T2)Value);
        }
    }

    public class Choice<T1, T2, T3>
    {
        public readonly int Case;
        public readonly object Value;

        public Choice(T1 value)
        {
            Case = 1;
            Value = value;
        }

        public Choice(T2 value)
        {
            Case = 2;
            Value = value;
        }

        public Choice(T3 value)
        {
            Case = 3;
            Value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1,
            Func<T2, TResult> func2,
            Func<T3, TResult> func3)
        {
#if DEBUG
            if (func1 == null) throw new ArgumentNullException(nameof(func1));
            if (func2 == null) throw new ArgumentNullException(nameof(func2));
            if (func3 == null) throw new ArgumentNullException(nameof(func3));
#endif
            return
                Case == 1 ? func1((T1)Value)
                : Case == 2 ? func2((T2)Value)
                : func3((T3)Value);
        }

        public void Match(
            Action<T1> action1,
            Action<T2> action2,
            Action<T3> action3)
        {
#if DEBUG
            if (action1 == null) throw new ArgumentNullException(nameof(action1));
            if (action2 == null) throw new ArgumentNullException(nameof(action2));
            if (action3 == null) throw new ArgumentNullException(nameof(action3));
#endif
            if (Case == 1) action1((T1)Value);
            else if (Case == 2) action2((T2)Value);
            else action3((T3)Value);
        }
    }

    public class Choice<T1, T2, T3, T4>
    {
        public readonly int Case;
        public readonly object Value;

        public Choice(T1 value)
        {
            Case = 1;
            Value = value;
        }

        public Choice(T2 value)
        {
            Case = 2;
            Value = value;
        }

        public Choice(T3 value)
        {
            Case = 3;
            Value = value;
        }

        public Choice(T4 value)
        {
            Case = 4;
            Value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1,
            Func<T2, TResult> func2,
            Func<T3, TResult> func3,
            Func<T4, TResult> func4)
        {
#if DEBUG
            if (func1 == null) throw new ArgumentNullException(nameof(func1));
            if (func2 == null) throw new ArgumentNullException(nameof(func2));
            if (func3 == null) throw new ArgumentNullException(nameof(func3));
            if (func4 == null) throw new ArgumentNullException(nameof(func4));
#endif
            return
                Case == 1 ? func1((T1)Value)
                : Case == 2 ? func2((T2)Value)
                : Case == 3 ? func3((T3)Value)
                : func4((T4)Value);
        }

        public void Match(
            Action<T1> action1,
            Action<T2> action2,
            Action<T3> action3,
            Action<T4> action4)
        {
#if DEBUG
            if (action1 == null) throw new ArgumentNullException(nameof(action1));
            if (action2 == null) throw new ArgumentNullException(nameof(action2));
            if (action3 == null) throw new ArgumentNullException(nameof(action3));
            if (action4 == null) throw new ArgumentNullException(nameof(action4));
#endif
            if (Case == 1) action1((T1)Value);
            else if (Case == 2) action2((T2)Value);
            else if (Case == 3) action3((T3)Value);
            else action4((T4)Value);
        }
    }

    public class Choice<T1, T2, T3, T4, T5>
    {
        public readonly int Case;
        public readonly object Value;

        public Choice(T1 value)
        {
            Case = 1;
            Value = value;
        }

        public Choice(T2 value)
        {
            Case = 2;
            Value = value;
        }

        public Choice(T3 value)
        {
            Case = 3;
            Value = value;
        }

        public Choice(T4 value)
        {
            Case = 4;
            Value = value;
        }

        public Choice(T5 value)
        {
            Case = 5;
            Value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1,
            Func<T2, TResult> func2,
            Func<T3, TResult> func3,
            Func<T4, TResult> func4,
            Func<T5, TResult> func5)
        {
#if DEBUG
            if (func1 == null) throw new ArgumentNullException(nameof(func1));
            if (func2 == null) throw new ArgumentNullException(nameof(func2));
            if (func3 == null) throw new ArgumentNullException(nameof(func3));
            if (func4 == null) throw new ArgumentNullException(nameof(func4));
            if (func5 == null) throw new ArgumentNullException(nameof(func5));
#endif
            return
                Case == 1 ? func1((T1)Value)
                : Case == 2 ? func2((T2)Value)
                : Case == 3 ? func3((T3)Value)
                : Case == 4 ? func4((T4)Value)
                : func5((T5)Value);
        }

        public void Match(
            Action<T1> action1,
            Action<T2> action2,
            Action<T3> action3,
            Action<T4> action4,
            Action<T5> action5)
        {
#if DEBUG
            if (action1 == null) throw new ArgumentNullException(nameof(action1));
            if (action2 == null) throw new ArgumentNullException(nameof(action2));
            if (action3 == null) throw new ArgumentNullException(nameof(action3));
            if (action4 == null) throw new ArgumentNullException(nameof(action4));
            if (action5 == null) throw new ArgumentNullException(nameof(action5));
#endif
            if (Case == 1) action1((T1)Value);
            else if (Case == 2) action2((T2)Value);
            else if (Case == 3) action3((T3)Value);
            else if (Case == 4) action4((T4)Value);
            else action5((T5)Value);
        }
    }

    public class Choice<T1, T2, T3, T4, T5, T6>
    {
        public readonly int Case;
        public readonly object Value;

        public Choice(T1 value)
        {
            Case = 1;
            Value = value;
        }

        public Choice(T2 value)
        {
            Case = 2;
            Value = value;
        }

        public Choice(T3 value)
        {
            Case = 3;
            Value = value;
        }

        public Choice(T4 value)
        {
            Case = 4;
            Value = value;
        }

        public Choice(T5 value)
        {
            Case = 5;
            Value = value;
        }

        public Choice(T6 value)
        {
            Case = 6;
            Value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1,
            Func<T2, TResult> func2,
            Func<T3, TResult> func3,
            Func<T4, TResult> func4,
            Func<T5, TResult> func5,
            Func<T6, TResult> func6)
        {
#if DEBUG
            if (func1 == null) throw new ArgumentNullException(nameof(func1));
            if (func2 == null) throw new ArgumentNullException(nameof(func2));
            if (func3 == null) throw new ArgumentNullException(nameof(func3));
            if (func4 == null) throw new ArgumentNullException(nameof(func4));
            if (func5 == null) throw new ArgumentNullException(nameof(func5));
            if (func6 == null) throw new ArgumentNullException(nameof(func6));
#endif
            return
                Case == 1 ? func1((T1)Value)
                : Case == 2 ? func2((T2)Value)
                : Case == 3 ? func3((T3)Value)
                : Case == 4 ? func4((T4)Value)
                : Case == 5 ? func5((T5)Value)
                : func6((T6)Value);
        }

        public void Match(
            Action<T1> action1,
            Action<T2> action2,
            Action<T3> action3,
            Action<T4> action4,
            Action<T5> action5,
            Action<T6> action6)
        {
#if DEBUG
            if (action1 == null) throw new ArgumentNullException(nameof(action1));
            if (action2 == null) throw new ArgumentNullException(nameof(action2));
            if (action3 == null) throw new ArgumentNullException(nameof(action3));
            if (action4 == null) throw new ArgumentNullException(nameof(action4));
            if (action5 == null) throw new ArgumentNullException(nameof(action5));
            if (action6 == null) throw new ArgumentNullException(nameof(action6));
#endif
            if (Case == 1) action1((T1)Value);
            else if (Case == 2) action2((T2)Value);
            else if (Case == 3) action3((T3)Value);
            else if (Case == 4) action4((T4)Value);
            else if (Case == 5) action5((T5)Value);
            else action6((T6)Value);
        }
    }
}
