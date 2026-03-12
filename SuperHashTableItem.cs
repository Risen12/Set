using System.Collections.Generic;

namespace ConsoleApp1;

public class SuperHashTableItem<T>
{
    public int Key { get; set; }
    public List<T> Nodes { get; set; }

    public SuperHashTableItem(int key)
    {
        Key = key;
        Nodes = new List<T>();
    }
}