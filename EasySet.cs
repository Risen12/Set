using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1;

internal class EasySet<T>
{
    private List<T> _items;
    
    public EasySet()
    {
        _items = new List<T>();
    }

    public EasySet(IEnumerable<T> items)
    {
        _items = new List<T>(items);
    }

    public int Count => _items.Count;

    public void Add(T item)
    {
        if (_items.Contains(item) == true)
        {
            return;
        }
        
        _items.Add(item);
    }
    
    public void Remove(T item) => _items.Remove(item);

    public EasySet<T> Union(EasySet<T> otherSet)
    {
        EasySet<T> result = new EasySet<T>();
        
        foreach (var item in _items)
        {
            result.Add(item);
        }

        foreach (var item in otherSet._items)
        {
            result.Add(item);
        }

        return result;
    }

    public EasySet<T> Intersect(EasySet<T> otherSet)
    {
        var result = new EasySet<T>();
        EasySet<T> small;
        EasySet<T> large;

        if (Count >= otherSet.Count)
        {
            large = this;
            small = otherSet;
        }
        else
        {
            large = otherSet;
            small = this;
        }

        foreach (var item in small._items)
        {
            foreach (var otherItem in large._items)
            {
                if (item.Equals(otherItem) == true)
                {
                    result.Add(item);
                    break;
                }
            }
        }
        
        return result;
    }

    public EasySet<T> Difference(EasySet<T> otherSet)
    {
        var result = new EasySet<T>(_items);

        foreach (var item in otherSet._items)
        {
            result.Remove(item);
        }
        
        return result;
    }

    public bool SubSet(EasySet<T> otherSet)
    {
        bool equals;
        
        foreach (var item in otherSet._items)
        {
            equals = false;
            
            foreach (var item1 in _items)
            {
                if (item1.Equals(item) == true)
                {
                    equals = true;
                    break;
                }
            }

            if (equals == false)
            {
                return false;
            }
        }
        
        return true;
    }

    public EasySet<T> SymmetricDifference(EasySet<T> otherSet)
    {
        var result = new EasySet<T>();
        bool equals;

        foreach (var item in _items)
        {
            equals = false;
            
            foreach (var item1 in otherSet._items)
            {
                if (item.Equals(item1) == true)
                {
                    equals = true;
                    break;
                }
            }

            if (equals == false)
            {
                result.Add(item);
            }
        }
        
        foreach (var item in otherSet._items)
        {
            equals = false;
            
            foreach (var item1 in _items)
            {
                if (item.Equals(item1) == true)
                {
                    equals = true;
                    break;
                }
            }

            if (equals == false)
            {
                result.Add(item);
            }
        }
        
        return result;
    }

    public void ViewSet()
    {
        foreach (var item in _items.ToList())
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}