using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> xs)
        {
            while(true)
            {
                foreach(T x in xs)
                {
                    yield return x;
                }
            }
        }
    }
}
