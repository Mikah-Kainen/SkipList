using System;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    public class Node<T> where T : IComparable<T>
    {
        public List<Node<T>> Children = new List<Node<T>>();
        public T Value;
        public int Height;
        public Node(T Value, int Height)
        {
            this.Value = Value;
            this.Height = Height;
        }


    }
}
