using System;
using System.Collections;

namespace SkipList
{
    class Program
    {
        static void Main(string[] args)
        {
            SkipList<int> list = new SkipList<int>();
            list.Add(5);
            list.Add(10);
            //list.Add(7);
            ;
        }
    }
}
