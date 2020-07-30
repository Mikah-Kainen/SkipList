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
            while (random.Next(0, 2) != 0 && currentHeight <= Head.Height)
            {
                currentHeight++;
            }
            if(currentHeight > Head.Height)
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
                for(int i = 0; i <= node.Height; i ++)
                {
                    Head.Children.Add(node);
                }
                return;
            }
            Add(node);
        }

        public void Add(T value)
        {

        }

        private void Add(Node<T> node)
        {
            Node<T> startingNode = Head;
            Stack<Node<T>> Heads = new Stack<Node<T>>();

            for(int i = 0; i <= node.Height; i ++)
            {
                node.Children.Add(new Node<T>(default, 0));
            }
            for(int currentHeight = Head.Height - 1; currentHeight >= 0; currentHeight --)
            {
                while(startingNode.Children.Count > currentHeight && !startingNode.Children[currentHeight].Equals(node))
                {
                    if (startingNode.Children[currentHeight].Value.CompareTo(node.Value) > 0)
                    {
                        if (node.Height <= currentHeight)
                        {
                            Node<T> tempHolder = startingNode.Children[currentHeight];
                            startingNode.Children[currentHeight] = node;
                            node.Children[currentHeight] = tempHolder;
                        }
                    }
                    else
                    {
                        startingNode = startingNode.Children[currentHeight];
                    }
                }
                if(startingNode.Children.Count <= currentHeight)
                {
                    Heads.Push(startingNode);
                }
            }

            while(Heads.Count > 0)
            {
                Heads.Pop().Children.Add(node);
            }
        }

        //private void Add(Node<T> node)
        //{
        //    Node<T> startingNode = Head;
        //    for (int currentHeight = 0; currentHeight <= node.Height; currentHeight ++)
        //    {
        //        while (startingNode.Children.Count > currentHeight && !startingNode.Children[currentHeight].Equals(node))
        //        {
        //            if (startingNode.Children[currentHeight].Value.CompareTo(node.Value) > 0)
        //            {
        //                Node<T> tempHolder = startingNode.Children[currentHeight];
        //                startingNode.Children[currentHeight] = node;
        //                node.Children.Add(tempHolder);
        //            }
        //            else
        //            {
        //                startingNode = startingNode.Children[currentHeight];
        //            }
        //        }

        //        if(startingNode.Children.Count <= currentHeight)
        //        {
        //            startingNode.Children.Add(node);
        //        }
        //    }
        //        //startingNode.Children.Add(node);
        //        //int count = currentHeight;
        //        //while (startingNode.Children.Count < currentHeight)
        //        //{
        //        //    startingNode.Children.Add(node);
        //        //    count--;
        //        //}
        //        //currentHeight = count;
        //}
    

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
