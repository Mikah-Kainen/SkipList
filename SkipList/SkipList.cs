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

        public Node<T> FindNode(T value)
        {
            Node<T> currentNode = Head;

            int currentHeight = Head.Height;
            while (currentNode.Value.CompareTo(value) != 0)
            {
                while (value.CompareTo(currentNode.Children[currentHeight].Value) < 0)
                {
                    currentHeight--;
                }
                currentNode = currentNode.Children[currentHeight];
            }
            return currentNode;
        }

        public Node<T> FindPreviousNode(T value)
        {
            Node<T> currentNode = Head;

            int currentHeight = Head.Height;
            while (currentHeight >= 0)
            {
                while (value.CompareTo(currentNode.Children[currentHeight].Value) < 0)
                {
                    currentHeight--;
                }
                if(currentNode.Children[currentHeight].Value.Equals(value))
                {
                    return currentNode;
                }
                currentNode = currentNode.Children[currentHeight];
            }
            return null;
        }

        public void Add(T value)
        {
            Node<T> previousNode = FindPreviousNode(value);
            if(previousNode == null)
            {
                previousNode = Head;
            }
            int height = previousNode.Height;

            while (height >= 0)
            {
                if (previousNode.Children[height].Children[height].Value.CompareTo(value) > 0)
                {
                    Node<T> tempHolder = previousNode.Children[height];
                    previousNode.Children[height] = new Node<T>(value, CreateHeight());
                    previousNode.Children[height].Children[height] = tempHolder;
                    height--;
                }
                else
                {
                    previousNode = previousNode.Children[height].Children[height];
                }
            }
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
