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
        public Node<T> Tail;



        public bool IsReadOnly => false;

        public SkipList()
        {
            Head = new Node<T>(default, 0);
            Tail = new Node<T>(default, 0);
            Head.Children.Add(Tail);
        }

        public int CreateHeight()
        {
            Random random = new Random();
            int currentHeight = 0;
            while (random.Next(0, 2) != 0 && currentHeight < Head.Height)
            {
                currentHeight++;
            }
            if (currentHeight == Head.Height)
            {
                Head.UpdateHeight(Head.Height + 1);
                Head.Children.Add(Tail);
            }
            Tail.UpdateHeight(Head.Height);
            return currentHeight;
        }

        public Node<T> FindNode(T value)
        {
            Node<T> currentNode = Head;

            int currentHeight = Head.Height;
            while (currentNode.Value.CompareTo(value) != 0 && !currentNode.Children[0].Equals(Tail))
            {
                while (currentNode.Children[currentHeight].Equals(Tail) || value.CompareTo(currentNode.Children[currentHeight].Value) < 0)
                {
                    currentHeight--;
                }
                currentNode = currentNode.Children[currentHeight];
            }
            return currentNode;
        }

        public Node<T> FindPreviousNode(T targetValue)
        {
            Node<T> currentNode = Head;
            Node<T> previousNode = Head;

            int currentHeight = Head.Height;
            while (currentNode.Value.CompareTo(targetValue) != 0 && !currentNode.Children[0].Equals(Tail))
            {
                while (currentNode.Children[currentHeight].Equals(Tail) || targetValue.CompareTo(currentNode.Children[currentHeight].Value) < 0)
                {
                    currentHeight--;
                }
                previousNode = currentNode;
                currentNode = currentNode.Children[currentHeight];
            }
            return previousNode;
        }

        private Node<T> FindPreviousNode(Node<T> targetNode, Node<T> startingNode, int startingHeight)
        {
            Node<T> currentNode = startingNode;
            Node<T> previousNode = startingNode;

            int currentHeight = startingHeight;
            while (!currentNode.Equals(targetNode) && !currentNode.Children[0].Equals(Tail))
            {
                while (currentNode.Children[currentHeight].Equals(Tail) || targetNode.Value.CompareTo(currentNode.Children[currentHeight].Value) < 0)
                {
                    currentHeight--;
                }
                previousNode = currentNode;
                currentNode = currentNode.Children[currentHeight];
            }
            return previousNode;
        }

        public bool Remove(T targetValue)
        {
            Node<T> targetNode = FindNode(targetValue);
            if(targetNode == Head || targetNode == Tail)
            {
                return false;
            }
            Node<T> currentNode = Head;

            currentNode = FindPreviousNode(targetNode, currentNode, Head.Height);
            currentNode.Children[targetNode.Height] = currentNode.Children[targetNode.Height].Children[targetNode.Height];

            for (int currentHeight = targetNode.Height - 1; currentHeight >= 0; currentHeight--)
            {
                currentNode = FindPreviousNode(targetNode, currentNode, currentHeight);
                currentNode.Children[currentHeight] = currentNode.Children[currentHeight].Children[currentHeight];
            }

            Count--;
            return true;
        } 

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value, CreateHeight());
            Count++;
            if (Head.Children.Count == 0)
            {
                for (int i = 0; i <= node.Height; i++)
                {
                    Head.Children.Add(node);
                }
                return;
            }
            Add(node);
        }

        public void Add(T value, int Height)
        {
            Node<T> node = new Node<T>(value, Height);
            Count++;
            if (Head.Children[0] == Tail)
            {
                Head.Children[0] = node;
                node.Children.Add(Tail);
                return;
            }
            Add(node);
        }

        private void Add(Node<T> node)
        {
            Node<T> currentNode = Head;

            for(int currentHeight = Head.Height - 1; currentHeight >= 0; currentHeight --)
            {
                while(currentNode.Children[currentHeight].Value.CompareTo(node.Value) < 0 && currentNode.Children[currentHeight] != Tail)
                {
                    currentNode = currentNode.Children[currentHeight];
                }
                if(currentHeight > node.Height)        {               }
                else
                {
                    node.Children.Insert(0, currentNode.Children[currentHeight]);
                    currentNode.Children[currentHeight] = node;
                }
            }
        }

        //public Node<T> Find(T targetValue)
        //{
        //    Node<T> currentNode = Head;
        //    for(int currentHeight = Head.Height; currentHeight >= 0; currentHeight --)
        //    {
        //        while (currentNode.Children[currentHeight].Value.CompareTo(targetValue) < 0 && !currentNode.Children[currentHeight].Equals(Tail))
        //        {
        //            currentNode = currentNode.Children[currentHeight];
        //        }
        //        if(currentNode.Children[currentHeight].Value.Equals(targetValue))
        //        {
        //            return currentNode.Children[currentHeight];
        //        }
        //    }
        //    return null;
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
