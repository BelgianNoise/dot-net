using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static int Count<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            int res = 0;
            foreach(T x in xs)
            {
                if(predicate(x))
                {
                    res++;
                }
            }
            return res;
        }
    }
}
