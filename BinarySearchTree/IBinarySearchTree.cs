using System;

namespace BinarySearchTree
{
    public interface IBinarySearchTree<T>
        where T : IComparable, IComparable<T>
    {
        Node<T> Root { get; }
        void Insert(Node<T> node);
        void InOrderTreeWalk(Node<T> node);
        Node<T> TreeSearch(Node<T> node, int key);
        void TreeDelete(int key);
    }
}