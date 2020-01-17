using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise
{
    public static class Student
    {
        public static IEnumerable<int> Ages(this IEnumerable<Person> people)
        {
            return people.Select(p => p.Age);
        }
        public static IEnumerable<Person> Women(this IEnumerable<Person> people)
        {
            return people.Where(p => !p.IsMale);
        }
        public static int CountMen(this IEnumerable<Person> people)
        {
            return people.Count(p => p.IsMale);
        }
        public static Person OldestMan(this IEnumerable<Person> people)
        {
            return people.Where(p => p.IsMale)
                .OrderByDescending(p => p.Age).First();
        }
        public static bool PersonWithAgeBetweenExists(this IEnumerable<Person> people, 
            int min, int max)
        {
            return people.Any(p => p.Age >= min && p.Age <= max);
        }
    }
}
