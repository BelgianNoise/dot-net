using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static IEnumerable<T> TakeN<T>(this IEnumerable<T> xs, int n)
        {
            foreach (var x in xs)
            {
                if (n <= 0)
                {
                    yield break;
                }
                else
                {
                    n--;
                    yield return x;
                }
            }
        }
    }
}
