using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise
{
    public static class Student
    {
        public static IEnumerable<T> Alternate<T>(this IEnumerable<T> xs, 
            IEnumerable<T> ys)
        {
            var temp = xs.Zip(ys, (x, y) => new List<T>() {x,y});
            foreach(var t in temp)
            {
                foreach(var tt in t)
                {
                    yield return tt;
                }
            }
        }
    }
}
