using System;

namespace BinarySearchTree
{
    public class Node<T>
    {
        public T Key;
        public Node<T> Parent;
        public Node<T> Left;
        public Node<T> Right;
    }
}