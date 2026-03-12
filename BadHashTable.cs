namespace ConsoleApp1;

public class BadHashTable<T>
{
    private T[] _items;
    
    public BadHashTable(int size)
    {
        _items = new T[size];
    }

    public void Add(T item)
    {
        var key = GetHash(item);
        _items[key] = item;
    }

    public bool Search(T item)
    {
        var key = GetHash(item);
        
        return _items[key].Equals(item);
    }

    private int GetHash(T item)
    {
        return item.ToString().Length % _items.Length;
    }
}