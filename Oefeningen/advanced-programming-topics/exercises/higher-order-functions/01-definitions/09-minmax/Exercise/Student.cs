using System;
using System.Collections.Generic;
using System.Text;

namespace Count
{
    public static class Student
    {
        public static T Maximum<T>(this IEnumerable<T> xs) where T : IComparable<T>
        {
            return xs.Maximum((x, y) => x.CompareTo(y) < 0);
        }
        public static T Minimum<T>(this IEnumerable<T> xs) where T : IComparable<T>
        {
            return xs.Maximum((x, y) => y.CompareTo(x) < 0);
        }
        public static T Maximum<T>(this IEnumerable<T> xs, 
            Func<T, T, bool> lessThan)
        {
            T res = default;
            bool first = true;

            foreach(T x in xs)
            {
                if( first )
                {
                    res = x;
                    first = false;
                }
                else if(lessThan(res, x))
                {
                    res = x;
                }
            }
            return res;
        }
        public static T Minimum<T>(this IEnumerable<T> xs,
            Func<T, T, bool> lessThan) 
        {
            return xs.Maximum((x, y) => lessThan(y, x));
        }
        public static T Maximum<T, K>(this IEnumerable<T> xs,
            Func<T, K> keyFunction) where K : IComparable<K>
        {
            return xs.Maximum((x, y) =>
                keyFunction(x).CompareTo(keyFunction(y)) < 0);
        }
        public static T Minimum<T, K>(this IEnumerable<T> xs,
            Func<T, K> keyFunction) where K : IComparable<K>
        {
            return xs.Maximum((x, y) =>
                keyFunction(y).CompareTo(keyFunction(x)) < 0);
        }
    }
}
