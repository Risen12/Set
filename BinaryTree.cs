using System;
using System.Collections.Generic;

namespace ConsoleApp1;

public class BinaryTree<T> where T : IComparable
{
    private TreeNode<T> _root;
    private int _count;
    
    public BinaryTree()
    {
        _count = 0;
        _root = null;
    }

    public void Add(T data)
    {
        var node = new TreeNode<T>(data);

        if (_root == null)
        {
            _root = node;
            return;
        }
        
        _root.Add(node);
    }

    public List<T> PreOrder()
    {
        if (_root == null)
            return new List<T>();

        return GetNodeDataPreOder(_root);
    }
    
    public List<T> PostOrder()
    {
        if (_root == null)
            return new List<T>();

        return GetNodeDataPostOder(_root);
    }

    public List<T> InOrder()
    {
        if (_root == null)
            return new List<T>();

        return GetNodeDataInOrder(_root);
    }

    private List<T> GetNodeDataInOrder(TreeNode<T> node)
    {
        var list = new List<T>();
        
        if (node != null)
        {
            if (node.Left != null)
            {
                list.AddRange(GetNodeDataInOrder(node.Left));
            }
            
            list.Add(node.Data);
            
            if (node.Right != null)
            {
                list.AddRange(GetNodeDataInOrder(node.Right));
            }
        }

        return list;
    }

    private List<T> GetNodeDataPreOder(TreeNode<T> node)
    {
        var list = new List<T>();
        
        if (node != null)
        {
            list.Add(node.Data);
            
            if (node.Left != null)
            {
                list.AddRange(GetNodeDataPreOder(node.Left));
            }
            if (node.Right != null)
            {
                list.AddRange(GetNodeDataPreOder(node.Right));
            }
        }

        return list;
    }

    private List<T> GetNodeDataPostOder(TreeNode<T> node)
    {
        var list = new List<T>();
        
        if (node != null)
        {
            if (node.Left != null)
            {
                list.AddRange(GetNodeDataPostOder(node.Left));
            }
            if (node.Right != null)
            {
                list.AddRange(GetNodeDataPostOder(node.Right));
            }
            
            list.Add(node.Data);
        }

        return list;
    }
}