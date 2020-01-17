using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise
{
    public static class Student
    {
        public static int CountTurns(this IEnumerable<int> ns)
        {
            var deltas = ns.Zip(ns.Skip(1), (x, y) => y - x);
            return deltas.Zip(deltas.Skip(1), (x,y) => 
            (x > 0 && y < 0) || (x < 0 && y > 0) ? 1 : 0
            ).Where(x => x == 1).Count();
        }
    }
}
