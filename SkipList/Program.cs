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

        }
    }
}
