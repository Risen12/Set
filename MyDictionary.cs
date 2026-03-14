using System;
using System.Collections;

namespace ConsoleApp1;

public class MyDictionary<TKey, TValue> : IEnumerable
{
    private DictItem<TKey, TValue>[] _items;
    private int _size;

    public MyDictionary(int startSize)
    {
        _items = new DictItem<TKey, TValue>[startSize];
        _size = _items.Length;
    }
    
    public int Size =>  _size;

    public void Add(DictItem<TKey, TValue> item) 
    {
        var hash = GetHash(item.Key);

        if (_items[hash] == null)
        {
            _items[hash] = item;
            return;
        }
        else
        {
            bool isAdded = false;

            for (int i = hash; i < _items.Length; i++)
            {
                if (_items[i].Key.Equals(item.Key))
                {
                    return;
                }

                if (_items[i] == null)
                {
                    _items[i] = item;
                    isAdded = true;
                    break;
                }
            }

            if (isAdded == false)
            {
                for (int i = 0; i < hash; i++)
                {
                    if (_items[i].Key.Equals(item.Key))
                    {
                        return;
                    }

                    if (_items[i] == null)
                    {
                        _items[i] = item;
                        isAdded = true;
                        break;
                    }
                }
            }

            if (isAdded == false)
            {
                throw new Exception("Словарь заполнен!");
            }
        }
    }

    public void Remove(TKey key)
    {
        var hash =  GetHash(key);

        if (_items[hash] == null)
        {
            return;
        }

        if (_items[hash].Key.Equals(key))
        {
            _items[hash] = null;
        }
        else
        {
            bool isRemoved = false;
            
            for (int i = hash; i < _items.Length; i++)
            {
                if (_items[i].Key.Equals(key))
                {
                    _items[i] = null;
                    return;
                }

                if (_items[i] == null)
                {
                    return;
                }
            }
            
            if (isRemoved == false)
            {
                for (int i = 0; i < hash; i++)
                {
                    if (_items[i].Key.Equals(key))
                    {
                        _items[i] = null;
                        return;
                    }

                    if (_items[i] == null)
                    {
                        return;
                    }
                }
            }
        }
    }

    public TValue Search(TKey key)
    {
        var hash =  GetHash(key);

        if (_items[hash] == null)
        {
            return default;
        }

        if (_items[hash].Key.Equals(key))
        {
            return _items[hash].Value;
        }
        else
        {
            bool isFound = false;
            
            for (int i = hash; i < _items.Length; i++)
            {
                if (_items[i].Key.Equals(key))
                {
                    return _items[i].Value;
                }

                if (_items[i] == null)
                {
                    return default;
                }
            }
            
            if (isFound == false)
            {
                for (int i = 0; i < hash; i++)
                {
                    if (_items[i].Key.Equals(key))
                    {
                        return _items[i].Value;
                    }

                    if (_items[i] == null)
                    {
                        return default;
                    }
                }
            }
        }
        
        return default;
    }

    private int GetHash(TKey key)
    {
        return key.GetHashCode() %  _size;
    }

    public IEnumerator GetEnumerator()
    {
        foreach (var item in _items)
        {
            if (item != null)
            {
                yield return item;
            }
        }
    }

    public void Show()
    {
        Console.WriteLine("Данные словаря:");
        foreach (var item in _items)
        {
            if (item != null)
            {
                Console.WriteLine(item);
            }
        }
    }
}