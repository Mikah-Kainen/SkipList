using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SkipList
{
    public class SkipList<T> : ICollection<T> where T : IComparable<T>
    {
        public int Count { get; private set; }
        public Node<T> Head;

        public bool IsReadOnly => throw new NotImplementedException();

        public SkipList()
        {
            Head = new Node<T>(default, 0);
        }

        public int CreateHeight()
        {
            Random random = new Random();
            int currentHeight = 0;
            while (random.Next(0, 2) != 0 && currentHeight < Head.Height)
            {
                currentHeight++;
            }
            if(currentHeight == Head.Height)
            {
                Head.Height++;
            }
            return currentHeight;
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
