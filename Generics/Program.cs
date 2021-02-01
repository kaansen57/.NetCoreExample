using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>();
            Console.WriteLine(myList.Count);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            Console.WriteLine(myList.Count);

           
            MyDictionary<int, string> myDictionary = new MyDictionary<int, string>();
            Console.WriteLine(myDictionary.Count);

            myDictionary.Add(1, "kaan");
            myDictionary.Add(2, "john");
            myDictionary.Add(3, "martin");
            myDictionary.Add(4, "hugo");

            Console.WriteLine(myDictionary.Count);

            for (int i = 0; i < myDictionary.Count; i++)
            {
                Console.WriteLine("Key: "+myDictionary.Keys[i] + " "+"Value: "+myDictionary.Values[i]);
            }
        }
    }
}
