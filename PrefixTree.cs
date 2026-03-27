using System.Reflection.Metadata;

namespace ConsoleApp1;

public class PrefixTree<T>
{
    private PrefixTreeNode<T> _root;

    public PrefixTree()
    {
        _root = new PrefixTreeNode<T>('/', default(T));
        Count = 1;
    }

    public int Count { get; private set; }
    
    private void AddNode(string  key, T data, PrefixTreeNode<T> node)
    {
        if (string.IsNullOrWhiteSpace(key) || string.IsNullOrEmpty(key))
        {
            if (node.IsWord == false)
            {
                node.Data = data;
                node.IsWord = true;
            }
        }
        else
        {
            var symbol = key[0];
            var subnode = node.TryFind(symbol);
            if (subnode != null)
            {
                AddNode(key.Substring(1), data, subnode);
            }
            else
            {
                var newNode = new PrefixTreeNode<T>(symbol, data);
                node.AddNode(symbol,  newNode);
                AddNode(key.Substring(1), data, newNode);
            }
        }
    }

    private void RemoveNode(string key,  PrefixTreeNode<T> node)
    {
        if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
        {
            if(node.IsWord == true)
                node.IsWord = false;
        }
        else
        {
            var symbol = key[0];
            var subNode = node.TryFind(symbol);

            if (subNode != null)
            {
                RemoveNode(key.Substring(1), subNode);
            }
        }
    }

    private bool Search(string key,  PrefixTreeNode<T> node, out T value)
    {
        value = default(T);
        var result = false;
        
        if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
        {
            if (node.IsWord == true)
            {
                value = node.Data;
                result = true;
            }
        }
        else
        {
            var symbol = key[0];
            var subNode = node.TryFind(symbol);

            if (subNode != null)
            {
                result = Search(key.Substring(1), subNode, out value);
            }
        }
        
        return result;
    }

    public void Add(string key, T data)
    {
        AddNode(key, data, _root);
    }

    public void Remove(string key)
    {
        RemoveNode(key, _root);
    }

    public bool TrySearch(string key, out T value)
    {
        return Search(key, _root, out value);
    }
}