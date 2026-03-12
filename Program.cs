using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            SuperHashTable<Person> superHashTable = new SuperHashTable<Person>(100);

            Person tom = new Person("Tom", 20);
            Person bob = new Person("Bob", 30);
            Person john = new Person("John", 25);
            Person alice =  new Person("Alice", 18);
            Person kate = new Person("Kate", 30);
            
            superHashTable.Add(tom);
            superHashTable.Add(bob);
            superHashTable.Add(john);

            Console.WriteLine(superHashTable.Search(new Person("Tom", 20)));
            Console.WriteLine(superHashTable.Search(tom));
            
            Console.ReadKey();
            
            HashTable<int, string> hashTable = new HashTable<int, string>(10);
            
            hashTable.Add(5, "Привет");
            hashTable.Add(18, "Мир");
            hashTable.Add(200, "Hello");
            hashTable.Add(5, "Hello!");

            Console.WriteLine(hashTable.Search(6, "Привет"));
            Console.WriteLine(hashTable.Search(18, "Мир"));

            Console.ReadKey();
            
            BadHashTable<int> badHashTable = new BadHashTable<int>(10);
            
            badHashTable.Add(5);
            badHashTable.Add(18);
            badHashTable.Add(200);

            Console.WriteLine(badHashTable.Search(6));
            Console.WriteLine(badHashTable.Search(18));
        }
    }
}

