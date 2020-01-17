using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class student
    {
        public static List<T> Filter<T>(this IEnumerable<T> xs, Func<T, bool> predicate)
        {
            List<T> res = new List<T>();

            foreach (var x in xs)
            {
                if(predicate(x))
                {
                    res.Add(x);
                }
            }
            return res;
        }
    }
}
