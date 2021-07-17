using System;

namespace BinarySearchTree
{
    public class BinerySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable, IComparable<T>
    {
        //Root of tree
        public Node<T> Root { get; set; }

        /// <summary>
        /// Inserts a node at it's correct position
        /// </summary>
        /// <param name="node">Node which has to be inserted</param>
        public void Insert(Node<T> node)
        {
            Node<T> temp = null;
            Node<T> root = Root;

            //finding end of the tree to insert
            while (root != null)
            {
                temp = root;
                if (node.Key.CompareTo(root.Key) == -1) //According to BST Property
                    root = root.Left;
                else
                    root = root.Right;
            }

            /*temp is holding refrence of node at end so
            making temp as parent of node which we want to insert*/
            node.Parent = temp;

            if (temp == null) //Again According to BST Property
                Root = node;
            else if (node.Key.CompareTo(temp.Key) == -1)
                temp.Left = node;
            else
                temp.Right = node;
        }

        /// <summary>
        /// Inorder tree walk which prints elements in sorted order
        /// </summary>
        /// <param name="node">Node where to start walk</param>
        public void InOrderTreeWalk(Node<T> node)
        {
            if (node != null)
            {
                InOrderTreeWalk(node.Left); //Recursive
                Console.WriteLine(node.Key); //Print
                InOrderTreeWalk(node.Right); //Recursive
            }
        }

        /// <summary>
        /// Search node using a key, returns a match
        /// </summary>
        /// <param name="node">Node where to start search</param>
        /// <param name="key">Search key</param>
        /// <returns>Match</returns>
        public Node<T> TreeSearch(Node<T> node, int key)
        {
            if (node == null || node.Key.CompareTo(key) == 0)
                return node;
            else if (node.Key.CompareTo(key) == -1)
                return TreeSearch(node.Right, key);
            else
                return TreeSearch(node.Left, key);
        }

        /// <summary>
        /// Returns minimum key value node
        /// </summary>
        /// <param name="node">Node where to start search</param>
        /// <returns>Match</returns>
        private Node<T> MinimumTree(Node<T> node)
        {
            if (node.Left != null)
                return MinimumTree(node.Left); //Minimum will be leftmost child
            return node;
        }

        /// <summary>
        /// Returns maximum key value node
        /// </summary>
        /// <param name="node">Node where to start search</param>
        /// <returns>Match</returns>
        private Node<T> MaximumTree(Node<T> node)
        {
            if (node.Right != null)
                return MaximumTree(node.Right); //Maximum will be rightmost child
            return node;
        }

        /// <summary>
        /// Transplant a node with another
        /// </summary>
        /// <param name="u">node which has to transplant</param>
        /// <param name="v">node which has to be placed in place of other</param>
        private void Transplant(Node<T> u, Node<T> v)
        {
            if (u.Parent == null) //If u is root itself
                Root = v;
            else if (u == u.Parent.Left) //If u is left child of it's parent
                u.Parent.Left = v; //Making v as left child of u's parent(replacing u)
            else
                u.Parent.Right = v;

            if (v != null)
                v.Parent = u.Parent;
        }

        /// <summary>
        /// Deletes a key matching node
        /// </summary>
        /// <param name="key">key to delete</param>
        public void TreeDelete(int key)
        {
            Node<T> nodeToDelete = TreeSearch(Root, key); //Searching which node to be deleted
            if (nodeToDelete.Left == null) //If Left child is null
                Transplant(nodeToDelete, nodeToDelete.Right); //Then transplant its right child on it's position
            else if (nodeToDelete.Right == null)
                Transplant(nodeToDelete, nodeToDelete.Left);
            else //If both children are available
            {
                Node<T> min = MinimumTree(nodeToDelete.Right); //Find minimum node in right subtree(successor)

                if (min.Parent != nodeToDelete) //if minimum is not a child of node we want to delete
                {
                    Transplant(min, min.Right); //Making min's right at min's place
                    min.Right = nodeToDelete.Right;
                    min.Right.Parent = min;
                }

                Transplant(nodeToDelete,
                    min); // If minimum is a child of node we want to delete then it will directly transplant
                min.Left = nodeToDelete.Left; //Making min's left is node's left which we want to delete
                min.Left.Parent = min;
            }
        }
    }
}