using System;

namespace ConsoleApp1;

public class BinaryTree<T> where T : IComparable
{
    private TreeNode<T> _root;
    
    public void Add(T data)
    {
        var node = new TreeNode<T>(data);

        if (_root == null)
        {
            _root = node;
            return;
        }

        var currentNode =  _root;

        while (true)
        {
            int compareResult = currentNode.CompareTo(node);

            if (compareResult >= 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = node;
                    return;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }
            else if (compareResult < 0)
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = node;
                    return;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }
        }
    }
}