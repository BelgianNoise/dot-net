using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static IEnumerable<T> DropN<T>(this IEnumerable<T> xs, int n)
        {
            int temp = 0;
            while(true)
            {
                foreach(T x in xs)
                {
                    if(temp < n) { temp++; }
                    else { yield return x; }
                }
            }
        }
    }
}
