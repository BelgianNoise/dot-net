using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise
{
    public static class Student
    {
        public static IEnumerable<T> Unique<T>(this IEnumerable<T> xs)
        {
            var set = new HashSet<T>();

            foreach (var x in xs)
            {
                if (!set.Contains(x))
                {
                    set.Add(x);
                    yield return x;
                }
            }
        }
    }
}
