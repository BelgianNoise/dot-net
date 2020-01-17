using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public static class Util
    {
        public static IEnumerable<T> Repeat<T>(T x)
        {
            while (true)
            {
                yield return x;
            }
        }
    }
}
