using System;
using System.Collections.Generic;

namespace ConsoleApp1;

public class PrefixTreeNode<T>
{
    private char _symbol;
    private Dictionary<char, PrefixTreeNode<T>> _subNodes;
    
    public PrefixTreeNode(char symbol, T data)
    {
        _symbol = symbol;
        Data = data;
        _subNodes = new Dictionary<char, PrefixTreeNode<T>>();
        IsWord = false;
    }

    public char Symbol => _symbol;
    
    public T Data { get;  set; }

    public bool IsWord { get;  set; }

    public override string ToString()
    {
        return Data.ToString();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        
        if (obj is PrefixTreeNode<T> node)
        {
            return Data.Equals(node.Data);
        }
        else
        {
            throw new ArgumentException($"Объект {obj.GetType()} невозможно сравнить с PrefixTreeNode!");
        }
    }

    public PrefixTreeNode<T> TryFind(char symbol)
    {
        if (_subNodes.TryGetValue(symbol, out var node))
            return  node;
        else
            return null;
    }

    public void AddNode(char key, PrefixTreeNode<T> node)
    {
        _subNodes.Add(key, node);
    }
}