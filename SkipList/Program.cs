using System;
using System.Collections;
using System.Collections.Generic;

namespace SkipList
{
    class Program
    {
        static void Main(string[] args)
        {

            //int? x = null;

            //if (x.HasValue)
            //{
            //    Console.WriteLine(x);
            //}


            //if (x != null)
            //{
            //    Console.WriteLine(x);
            //}

            //Console.WriteLine(x);
            SkipList<int> list = new SkipList<int>();
            list.Add(5);
            list.Add(10);
            list.Add(7);
            list.Add(6);
            list.Add(8);
            list.Add(13);
            list.Add(14);
            list.Add(12);

            list.Remove(7);
            list.Remove(5);
            list.Remove(14);
            list.Remove(12);

            //Node<int> node13 = list.FindPreviousNode(14);
            //Node<int> node7 = list.FindPreviousNode(8);
            //Node<int> node5 = list.FindPreviousNode(5);
            //Node<int> node11 = list.FindPreviousNode(12);
        }
    }
}
