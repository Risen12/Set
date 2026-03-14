using System;
using System.Globalization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            MyDictionary<int, string> myDictionary = new MyDictionary<int, string>(100);
            myDictionary.Add(new DictItem<int, string>(176, "Masha"));
            myDictionary.Add(new DictItem<int, string>(2, "Kara"));
            myDictionary.Add(new DictItem<int, string>(20, "Mike"));
            myDictionary.Add(new DictItem<int, string>(10, "Daria"));
            myDictionary.Add(new DictItem<int, string>(20, "Jerry"));
            
            myDictionary.Show();
            
            Console.ReadKey();
            
            myDictionary.Remove(2);
            myDictionary.Remove(201);
            myDictionary.Show();
            
            Console.ReadKey();

            Console.WriteLine(myDictionary.Search(176));
            Console.WriteLine(myDictionary.Search(20));
            Console.WriteLine(myDictionary.Search(100));
            
            Console.ReadKey();
        }
    }
}

