using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise
{
    public static class Student
    {
        public static int CountIncreasingSubsequences(this IEnumerable<int> ns)
        {
            return ns.Zip(ns.Skip(1), (x, y) => y - x)
                .Where(n => n < 0).Count() + 1;
        }
    }
}
