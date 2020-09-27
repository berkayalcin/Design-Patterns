using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator_Pattern
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            Left.Parent = Right.Parent = this;
        }
    }


    public class BinaryTree<T>
    {
        private Node<T> _root;

        public BinaryTree(Node<T> root)
        {
            _root = root;
        }

        public IEnumerable<Node<T>> InOrder
        {
            get
            {
                IEnumerable<Node<T>> Traverse(Node<T> current)
                {
                    if (current.Left != null)
                        foreach (var left in Traverse(current.Left))
                            yield return left;

                    yield return current;

                    if (current.Right != null)
                        foreach (var right in Traverse(current.Right))
                            yield return right;
                }

                foreach (var node in Traverse(_root))
                {
                    yield return node;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node<int>(
                1,
                new Node<int>(2),
                new Node<int>(3));

            var tree = new BinaryTree<int>(root);
            Console.Write(string.Join(',',
                tree.InOrder.Select(node => node.Value)));
        }
    }
}