using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class Mapper<T, R> : IEnumerable<R>
    {
        IList<R> res;
        IEnumerable<T> peeps;
        Func<T, R> f;
        public Mapper(IEnumerable<T> people, Func<T, R> ff)
        {
            this.peeps = people;
            this.f = ff;
        }

        public IEnumerator<R> GetEnumerator()
        {
            return new Enumerator(this.peeps.GetEnumerator(), this.f);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Enumerator : IEnumerator<R>
        {
            private readonly IEnumerator<T> enumerator;

            private readonly Func<T, R> f;

            public Enumerator(IEnumerator<T> enumerator, Func<T, R> ff)
            {
                this.enumerator = enumerator;
                this.f = ff;
            }

            public R Current => f(enumerator.Current);

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                enumerator.Dispose();
            }

            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }

            public void Reset()
            {
                enumerator.Reset();
            }
        }
    }

    public class Filter<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> originalData;

        private readonly Func<T, bool> predicate;

        public Filter(IEnumerable<T> originalData, Func<T, bool> predicate)
        {
            this.originalData = originalData;
            this.predicate = predicate;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.originalData.GetEnumerator(), this.predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Enumerator : IEnumerator<T>
        {
            private readonly IEnumerator<T> enumerator;

            private readonly Func<T, bool> predicate;

            public Enumerator(IEnumerator<T> enumerator, Func<T, bool> predicate)
            {
                this.enumerator = enumerator;
                this.predicate = predicate;
            }

            public T Current => enumerator.Current;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                enumerator.Dispose();
            }

            public bool MoveNext()
            {
                do
                {
                    if (!enumerator.MoveNext())
                    {
                        return false;
                    }
                } while (!predicate(enumerator.Current));

                return true;
            }

            public void Reset()
            {
                enumerator.Reset();
            }
        }
    }
}
