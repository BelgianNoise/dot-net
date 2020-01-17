using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise
{
    public static class Student
    {
        public static bool IsStepwise(this IEnumerable<int> ns)
        {
            return ns.Zip(ns.Skip(1), (x, y) => y - x)
                .All(n => new List<int>() {0, -1, 1}.Contains(n));
        }
    }
}
