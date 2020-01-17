using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise
{
    public static class Student
    {
        public static IEnumerable<int> Deltas(this IEnumerable<int> ns)
        {
            return ns.Zip(ns.Skip(1), (x, y) => y - x);
        }
    }
}
