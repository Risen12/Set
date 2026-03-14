using System.Runtime.InteropServices;

namespace ConsoleApp1;

public class DictItem<TKey, TValue>
{
    private  TKey _key;
    private TValue _value;
    
    public DictItem(TKey key, TValue value)
    {
        _key = key;
        _value = value;
    }
    
    public TKey Key =>  _key;
    public TValue Value => _value;

    public override int GetHashCode()
    {
        return _key.GetHashCode();
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}