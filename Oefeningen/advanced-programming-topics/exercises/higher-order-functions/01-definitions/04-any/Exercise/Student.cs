using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static bool Any<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            foreach (T x in xs)
            {
                if (predicate(x))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
