using System;

namespace ConsoleApp1;

public class TreeNode<T> : IComparable
    where T : IComparable
{
    private T _data;

    public TreeNode(T data)
    {
        _data = data;
    }

    public TreeNode(T data, TreeNode<T> left, TreeNode<T> right)
    {
        _data = data;
        Left = left;
        Right = right;
    }

    public T Data =>  _data;
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }

    public int CompareTo(object? obj)
    {
        if (obj is TreeNode<T> item)
        { 
            return _data.CompareTo(item.Data);
        }
        else
        {
            throw new Exception($"Невозможно сравнить тип {obj.GetType()} c TreeNode!");
        }
    }

    public void Add(TreeNode<T> node)
    {
        if (node.CompareTo(this) >= 0)
        {
            if (Right != null)
            {
                Right.Add(node);
            }
            else
            {
                Right = node;
            }
        }
        else
        {
            if (Left != null)
            {
                Left.Add(node);
            }
            else
            {
                Left = node;
            }
        }
    }
}