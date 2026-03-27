using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            PrefixTree<int> prefixTree = new PrefixTree<int>();
            
            prefixTree.Add("привет", 50);
            prefixTree.Add("мир", 100);
            prefixTree.Add("приз", 200);
            prefixTree.Add("проект", 500);
            prefixTree.Add("герой", 200);
            prefixTree.Add("город", 100);
            prefixTree.Add("март", 700);
            
            prefixTree.Remove("пока");
            prefixTree.Remove("мир");
            prefixTree.Remove("город");

            int result = 0;
            prefixTree.TrySearch("город", out result);
            Console.WriteLine(result);
            prefixTree.TrySearch("привет", out result);
            Console.WriteLine(result);
            prefixTree.TrySearch("облако", out result);
            Console.WriteLine(result);
            prefixTree.TrySearch("герой", out result);
            Console.WriteLine(result);

            Console.WriteLine("Рудд");
        }
    }
}

