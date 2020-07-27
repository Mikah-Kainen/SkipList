using System;
using System.Collections;

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

        }
    }
}
