using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(5);
            tree.Add(10);
            tree.Add(3);
            tree.Add(4);
            tree.Add(7);
            tree.Add(9);
            tree.Add(11);

            var list = tree.InOrder();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}

