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

        public bool IsReadOnly => false;

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
                Head.UpdateHeight(Head.Height + 1);
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

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value, CreateHeight());
            Count++;
            if(Head.Children.Count == 0)
            {
                for(int i = node.Height; i >= 0; i --)
                {
                    Head.Children.Add(node);
                }
                return;
            }
            Add(node);
        }

        private void Add(Node<T> node)
        {
            for(int currentHeight = node.Height; currentHeight >= 0; currentHeight --)
            {
                Node<T> startingNode = Head;
                while (startingNode.Children.Count < currentHeight)
                {
                    if (startingNode.Children[currentHeight].Value.CompareTo(node.Value) > 0)
                    {
                        Node<T> tempHolder = startingNode.Children[currentHeight];
                        startingNode.Children[currentHeight] = node;
                        node.Children[currentHeight] = tempHolder;
                    }
                    else
                    {
                        startingNode = startingNode.Children[currentHeight];
                    }
                }
                startingNode.Children.Add(node);
                int count = currentHeight;
                while (startingNode.Children.Count < currentHeight)
                {
                    startingNode.Children.Add(node);
                    count--;
                }
                currentHeight = count;
            }
        }

        //public Node<T> FindPreviousNode(T value)
        //{
        //    if(Head.Height == 0)
        //    {
        //        return Head;
        //    }
        //    Node<T> currentNode = Head;

        //    int currentHeight = Head.Height - 1;
        //    while (currentHeight >= 0)
        //    {
        //        while (currentNode.Children.Count != 0 && value.CompareTo(currentNode.Children[currentHeight].Value) < 0)
        //        {
        //            currentHeight--;
        //        }
        //        if(currentNode.Children.Count == 0 || currentNode.Children[currentHeight].Value.Equals(value))
        //        {
        //            return currentNode;
        //        }
        //        currentNode = currentNode.Children[currentHeight];
        //    }
        //    return null;
        //}

        //public void Add(T value)
        //{
        //    Node<T> previousNode = FindPreviousNode(value);
        //    if(previousNode == null)
        //    {
        //        throw new Exception("Something Bad Happened Exception");
        //    }
        //    else if(previousNode == Head)
        //    {
        //        if(Head.Height == 0)
        //        {
        //            Head.Children.Add(new Node<T>(value, CreateHeight()));
        //            return;
        //        }
        //    }
        //    int height = previousNode.Height;

        //    while (height >= 0)
        //    {
        //        if (previousNode.Children[height].Children[height].Value.CompareTo(value) > 0)
        //        {
        //            Node<T> tempHolder = previousNode.Children[height];
        //            previousNode.Children[height] = new Node<T>(value, CreateHeight());
        //            previousNode.Children[height].Children[height] = tempHolder;
        //            height--;
        //        }
        //        else
        //        {
        //            previousNode = previousNode.Children[height].Children[height];
        //        }
        //    }
        //}

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
            yield return Head.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
