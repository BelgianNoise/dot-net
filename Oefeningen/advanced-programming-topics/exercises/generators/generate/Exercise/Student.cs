using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static IEnumerable<T> Generate<T>(T initial, Func<T, T> successor)
        {
            T temp = initial;
            yield return temp;
            while(true)
            {
                T temp2 = successor(temp);
                yield return temp2;
                temp = temp2;
            }
        }
    }
}
