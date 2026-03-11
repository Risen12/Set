using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1;


internal class Program
{
    static void Main()
    {
        EasySet<int> set = new EasySet<int>();
        EasySet<int> otherSet = new EasySet<int>();
        EasySet<int> otherSet1 = new EasySet<int>();
        
        otherSet1.Add(1);
        otherSet1.Add(2);
        
        set.Add(1);
        set.Add(2);
        set.Add(3);
        set.Add(4);
        
        otherSet.Add(3);
        otherSet.Add(4);
        otherSet.Add(5);
        otherSet.Add(6);
        
        var differenceSet = otherSet.Difference(set);
        var intersectionSet = set.Intersect(otherSet);
        var symmetricDifference = set.SymmetricDifference(otherSet);
        
        differenceSet.ViewSet();
        intersectionSet.ViewSet();
        symmetricDifference.ViewSet();

        Console.WriteLine(set.SubSet(otherSet));
    }
}

