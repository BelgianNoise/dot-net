using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class student
    {
        public static List<R> Map<T, R>(this IEnumerable<T> xs, Func<T, R> function)
        {
            List<R> res = new List<R>();

            foreach(T x in xs)
            {
                res.Add(function(x));
            }
            return res;
        }
    }
}
