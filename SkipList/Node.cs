using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SkipList
{
    [DebuggerDisplay("Value: {Value}, Height: {Height}, Children Count: {Children.Count}")]
    public class Node<T> where T : IComparable<T>
    {
        public List<Node<T>> Children = new List<Node<T>>();
        public T Value { get; private set; }
        public int Height { get; private set; }
        public Node(T Value, int Height)
        {
            this.Value = Value;
            this.Height = Height;
        }

        public void UpdateHeight(int newheight)
        {
            Height = newheight;
        }


    }
}
