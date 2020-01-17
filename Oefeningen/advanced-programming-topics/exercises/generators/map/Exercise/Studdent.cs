using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Studdent
    {
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> xs, Func<T, R> f)
        {
            foreach(T x in xs)
            {
                yield return f(x);
            }
        }
    }
}
