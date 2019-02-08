using System;

namespace Functional
{
    public class Union<T1, T2>
    {
        readonly int _case;
        readonly object _value;

        public Union(T1 value)
        {
            _case = 1;
            _value = value;
        }

        public Union(T2 value)
        {
            _case = 2;
            _value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1, 
            Func<T2, TResult> func2) => 
            _case == 1 ? func1((T1)_value) 
            : func2((T2)_value);

        public void Match(
            Action<T1> action1,
            Action<T2> action2)
        {
            if (_case == 1) action1((T1)_value);
            else action2((T2)_value);
        }
    }

    public class Union<T1, T2, T3>
    {
        readonly int _case;
        readonly object _value;

        public Union(T1 value)
        {
            _case = 1;
            _value = value;
        }

        public Union(T2 value)
        {
            _case = 2;
            _value = value;
        }

        public Union(T3 value)
        {
            _case = 3;
            _value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1, 
            Func<T2, TResult> func2, 
            Func<T3, TResult> func3) =>
            _case == 1 ? func1((T1)_value) 
            : _case == 2 ? func2((T2)_value) 
            : func3((T3)_value);

        public void Match(
            Action<T1> action1,
            Action<T2> action2,
            Action<T3> action3)
        {
            if (_case == 1) action1((T1)_value);
            else if (_case == 2) action2((T2)_value);
            else action3((T3)_value);
        }
    }

    public class Union<T1, T2, T3, T4>
    {
        readonly int _case;
        readonly object _value;

        public Union(T1 value)
        {
            _case = 1;
            _value = value;
        }

        public Union(T2 value)
        {
            _case = 2;
            _value = value;
        }

        public Union(T3 value)
        {
            _case = 3;
            _value = value;
        }

        public Union(T4 value)
        {
            _case = 4;
            _value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1, 
            Func<T2, TResult> func2, 
            Func<T3, TResult> func3, 
            Func<T4, TResult> func4) =>
            _case == 1 ? func1((T1)_value) 
            : _case == 2 ? func2((T2)_value) 
            : _case == 3 ? func3((T3)_value) 
            : func4((T4)_value);

        public void Match(
            Action<T1> action1,
            Action<T2> action2,
            Action<T3> action3,
            Action<T4> action4)
        {
            if (_case == 1) action1((T1)_value);
            else if (_case == 2) action2((T2)_value);
            else if (_case == 3) action3((T3)_value);
            else action4((T4)_value);
        }
    }

    public class Union<T1, T2, T3, T4, T5>
    {
        readonly int _case;
        readonly object _value;

        public Union(T1 value)
        {
            _case = 1;
            _value = value;
        }

        public Union(T2 value)
        {
            _case = 2;
            _value = value;
        }

        public Union(T3 value)
        {
            _case = 3;
            _value = value;
        }

        public Union(T4 value)
        {
            _case = 4;
            _value = value;
        }

        public Union(T5 value)
        {
            _case = 5;
            _value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1, 
            Func<T2, TResult> func2, 
            Func<T3, TResult> func3, 
            Func<T4, TResult> func4, 
            Func<T5, TResult> func5) =>
            _case == 1 ? func1((T1)_value) 
            : _case == 2 ? func2((T2)_value) 
            : _case == 3 ? func3((T3)_value) 
            : _case == 4 ? func4((T4)_value) 
            : func5((T5)_value);

        public void Match(
            Action<T1> action1,
            Action<T2> action2,
            Action<T3> action3,
            Action<T4> action4,
            Action<T5> action5)
        {
            if (_case == 1) action1((T1)_value);
            else if (_case == 2) action2((T2)_value);
            else if (_case == 3) action3((T3)_value);
            else if (_case == 4) action4((T4)_value);
            else action5((T5)_value);
        }
    }

    public class Union<T1, T2, T3, T4, T5, T6>
    {
        readonly int _case;
        readonly object _value;

        public Union(T1 value)
        {
            _case = 1;
            _value = value;
        }

        public Union(T2 value)
        {
            _case = 2;
            _value = value;
        }

        public Union(T3 value)
        {
            _case = 3;
            _value = value;
        }

        public Union(T4 value)
        {
            _case = 4;
            _value = value;
        }

        public Union(T5 value)
        {
            _case = 5;
            _value = value;
        }

        public Union(T6 value)
        {
            _case = 6;
            _value = value;
        }

        public TResult Match<TResult>(
            Func<T1, TResult> func1,
            Func<T2, TResult> func2,
            Func<T3, TResult> func3,
            Func<T4, TResult> func4,
            Func<T5, TResult> func5,
            Func<T6, TResult> func6) =>
            _case == 1 ? func1((T1)_value)
            : _case == 2 ? func2((T2)_value)
            : _case == 3 ? func3((T3)_value)
            : _case == 4 ? func4((T4)_value)
            : _case == 5 ? func5((T5)_value)
            : func6((T6)_value);

        public void Match(
            Action<T1> action1,
            Action<T2> action2,
            Action<T3> action3,
            Action<T4> action4,
            Action<T5> action5,
            Action<T6> action6)
        {
            if (_case == 1) action1((T1)_value);
            else if (_case == 2) action2((T2)_value);
            else if (_case == 3) action3((T3)_value);
            else if (_case == 4) action4((T4)_value);
            else if (_case == 5) action5((T5)_value);
            else action6((T6)_value);
        }
    }
}
