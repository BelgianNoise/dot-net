using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise
{
    public static class Student
    {
        public static T FindFirst<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            foreach(T x in xs)
            {
                if(predicate(x))
                {
                    return x;
                }
            }
            throw new InvalidOperationException();
        }
        public static T FindLast<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            return FindFirst(xs.Reverse(), predicate);
        }
        public static int IndexOf<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            int res = 0;
            foreach (T x in xs)
            {
                if (predicate(x))
                {
                    return res;
                }
                res++;
            }
            throw new InvalidOperationException();
        }
    }
}
