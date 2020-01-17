using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static R Reduce<T, R>(this IEnumerable<T> xs, R acc, Func<T, R, R> f)
        {
            foreach(T x in xs)
            {
                acc = f(x, acc);
            }
            return acc;
        }
    }
}
