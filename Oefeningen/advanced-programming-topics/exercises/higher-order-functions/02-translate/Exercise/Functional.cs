using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Shared;

namespace Functional
{
    public static class Functions
    {
        public static T MaxTByKey<T, R>(this IEnumerable<T> xs, 
            Func<T, R> key) where R : IComparable<R>
        {
            T res = xs.First();
            foreach(T x in xs)
            {
                if(key(x).CompareTo(key(res)) > 0)
                {
                    res = x;
                }
            }
            return res;
        }
        // GET MAX RUNTIME IN INT
        public static int Query1(IEnumerable<Movie> movies)
        {
            return movies.Max(x => x.Runtime);
        }
        // GET MIN RUNTIME IN INT
        public static int Query2(IEnumerable<Movie> movies)
        {
            return movies.Min(x => x.Runtime);
        }
        // GET MAX RATING IN INT
        public static double Query3(IEnumerable<Movie> movies)
        {
            return movies.Max(x => x.Rating);
        }
        // GET MOVIE WITH MAX RATING
        public static Movie Query4(IEnumerable<Movie> movies)
        {
            return movies.MaxTByKey(x => x.Rating);
        }
        // RETURN ALF SORT LIST OF UNIQUE DIRECTORS
        public static IEnumerable<string> Query5(IEnumerable<Movie> movies)
        {
            return movies.Select(mov => mov.Director).Distinct().OrderBy(x => x);
        }
        // RETURN AMOUNT OF MOVIES WITH CAT ...
        public static int Query6(IEnumerable<Movie> movies)
        {
            return movies.Where(m => m.Genres.Contains(Genre.Documentary)).Count();
        }
        // GET AVG RNTIME FOR DIRECTOR
        public static double Query7(IEnumerable<Movie> movies, string director)
        {
            return movies.Where(m => m.Director == director).Sum(x => x.Runtime) / 
                (double)movies.Where(m => m.Director == director).Count();
        }
        // GET DICT OF DIRECTOR AND ALF SORT LIST OF MOVIES
        public static IDictionary<string, List<Movie>> Query8(
            IEnumerable<Movie> movies)
        {
            return movies.GroupBy(m => m.Director, m => m, 
                (dir, movs) => new{ Key = dir, Value = movs.OrderBy(x => x.Title) }).
                ToDictionary(p => p.Key, p => p.Value.ToList());
        }
        // GET DICT OF YEAR AND AMOUNT OF MOVIES IN YEAR
        public static IDictionary<int, int> Query9(IEnumerable<Movie> movies)
        {
            return movies.GroupBy(m => m.Year, m => m,
                (year, list) => new {Key = year, Value = list.Count()})
                .ToDictionary(p => p.Key, p => p.Value);
        }
        // GET LIST OF UNIQUE DIRECTORS WITH MIN n AMOUNT OF MOVIES ALF SORT
        public static IEnumerable<string> Query10(IEnumerable<Movie> movies, int n)
        {
            return movies.GroupBy(m => m.Director, m => m,
                (dir, list) => new {Key=dir, Value=list.Count()})
                .Where(p => p.Value >= n).Select(p => p.Key).Distinct()
                .OrderBy(x => x);
        }
        // GET DICT WITH UNIQUE DIRECTOR AND MAX RATING OF MOVIE
        public static IDictionary<string, Movie> Query11(IEnumerable<Movie> movies)
        {
            return movies.GroupBy(m => m.Director, m => m,
                (dir, list) => new { Key = dir, Value = list.MaxTByKey(m => m.Rating)})
                .ToDictionary(p => p.Key, p => p.Value);
        }
        // GET ALF SORT LIST OF DIRECTORS WITH NO MOVIES WITH RATING LOWER THEN n
        public static IEnumerable<string> Query12(IEnumerable<Movie> movies, double n)
        {
            return movies.GroupBy(m => m.Director, m => m,
                (dir, list) => new { Key = dir, Value = list.Min(m => m.Rating)})
                .Where(p => p.Value > n).Select(p => p.Key).Distinct()
                .OrderBy(m => m);
        }
    }
}
