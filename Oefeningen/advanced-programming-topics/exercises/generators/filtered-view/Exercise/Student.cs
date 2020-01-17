using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class FilteredView<T> : IList<T>
    {
        IList<T> list;
        Func<T, bool> f;
        public FilteredView(IList<T> l, Func<T, bool> ff)
        {
            this.list = l; this.f = ff;
        }

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count
        {
            get
            {
                int count = 0;

                foreach (var x in this.list)
                {
                    if (f(x))
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public bool IsReadOnly => true;

        public void Add(T item)
        {
            throw new InvalidOperationException();
        }

        public void Clear()
        {
            throw new InvalidOperationException();
        }

        public bool Contains(T item)
        {
            foreach(T x in this.list)
            {
                if(x.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach(T x in this.list)
            {
                array[arrayIndex] = x;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        public int IndexOf(T item)
        {
            int index = 0;
            foreach(T x in this.list)
            {
                if (x.Equals(item))
                {
                    return index;
                }
                else
                {
                    index++;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new InvalidOperationException();
        }

        public bool Remove(T item)
        {
            throw new InvalidOperationException();
        }

        public void RemoveAt(int index)
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new InvalidOperationException();
        }
    }
}
