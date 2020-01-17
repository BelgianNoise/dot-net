using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Student
    {
        public static IDictionary<R, List<T>> Group<T, R>(this IEnumerable<T> xs, 
            Func<T, R> categorizer)
        {
            Dictionary<R, List<T>> dict = new Dictionary<R, List<T>>();
            foreach(T x in xs)
            {
                R cat = categorizer(x);
                if(dict.ContainsKey(cat))
                {
                    List<T> lijst = dict[cat];
                    lijst.Add(x);
                    dict[cat] = lijst;
                }
                else
                {
                    List<T> lijst = new List<T>();
                    lijst.Add(x);
                    dict.Add(cat, lijst);
                }
            }
            return dict;
        }
    }
}
