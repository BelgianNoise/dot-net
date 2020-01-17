using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static Tuple<List<T>, List<T>> Partition<T>(this IEnumerable<T> xs, 
            Func<T, bool> predicate)
        {
            List<T> trues = new List<T>();
            List<T> falses = new List<T>();
            foreach(T x in xs)
            {
                if(predicate(x))
                {
                    trues.Add(x);
                }
                else 
                {
                    falses.Add(x);
                }
            }
            return Tuple.Create(trues, falses);
        }
    }
}
