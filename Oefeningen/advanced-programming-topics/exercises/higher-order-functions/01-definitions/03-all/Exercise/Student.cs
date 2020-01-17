using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static bool All<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            foreach(T x in xs)
            {
                if(!predicate(x))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
