using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BinaryTreeGenericCollection
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> _root;
        public Node<T> Root { get => _root; set => _root = value;}


        public BinaryTree(T key) 
        {
            _root = new Node<T>(key);
        }

        public BinaryTree() 
        {
            _root = null;
        }

        public void ValidationRoot()
        {
            if (_root == null) throw new ArgumentNullException("root");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> InOrderTraversal()
        {
            ValidationRoot();

            Stack<Node<T>> stack = new();
            Node<T> current = _root;

            while (current != null || stack.Count > 0) 
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                yield return current.Key;

                current = current.Right;

            }
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            ValidationRoot();

            Stack<Node<T>> stack = new();
            stack.Push(_root);

            while (stack.Count > 0)
            {
                Node<T> current = stack.Pop();
                yield return current.Key;

                if (current.Right != null) stack.Push(current.Right);
                if (current.Left != null) stack.Push(current.Left);
            }

        }

        public IEnumerable<T> PostOrderTraversal()
        {
            ValidationRoot();

            Stack<Node<T>> s1 = new();
            Stack<Node<T>> s2 = new();

            s1.Push(_root);

            while(s1.Count > 0)
            {
                Node<T> temp = s1.Pop();
                s2.Push(temp);

                if (temp.Left != null) s1.Push(temp.Left);
                if (temp.Right != null) s1.Push(temp.Right);
            }

            while (s2.Count > 0) yield return s2.Pop().Key;
        
        }


        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null) return new Node<T>(item);

            int compare = item.CompareTo(node.Key);
            node.Left = compare < 0 ? Insert(node.Left, item) : node.Left;
            node.Right = compare > 0 ? Insert(node.Right, item) : node.Right;

            return node;
        }

        public void Insert(T item, bool binarySearchTree = false)
        {
            if (binarySearchTree)
            {
                _root = Insert(_root, item);
                return;
            }

            Node<T> newNode = new(item);

            if (_root == null)
            {
                _root = newNode;
                return;
            }

            Queue<Node<T>> nodes = new();
            nodes.Enqueue(_root);

            InsertWhileOperation(newNode, nodes);

        }

        private void InsertWhileOperation(Node<T> newNode, Queue<Node<T>> nodes)
        {
            while (nodes.Count > 0)
            {
                Node<T> node = nodes.Dequeue();

                if(node.Left == null)
                {
                    node.Left = newNode;
                    return;
                }
                nodes.Enqueue(node.Left);

                if(node.Right == null)
                {
                    node.Right = newNode;
                    return;
                }
                nodes.Enqueue(node.Right);
            }
        }

        //public void Remove(T item)
        //{
        //    if (_root == null) throw new InvalidOperationException("no elements");
        //    if (FindItem(item) == false) throw new InvalidOperationException("item doesn't exist in tree");

        //    Node<T> nodeToDelete = FindItem(_root, item);
        //    Node<T> deepestRightNode = GetDeepestRightNode();

        //    if (nodeToDelete == deepestRightNode) { nodeToDelete = null; return; }


        //    nodeToDelete.Key = deepestRightNode.Key;
        //    DeleteDeepestRightNode(deepestRightNode);    
        //}
        public void Remove(T item)
        {
            _root = Remove(_root, item);
        }

        private Node<T> Remove(Node<T> root, T item)
        {
            if (root == null) return root;
            int compare = item.CompareTo(root.Key);

            if (compare < 0) root.Left = Remove(root.Left, item);
            else if (compare > 0) root.Right = Remove(root.Right, item);
            
            else root = RemoveCheckChildsOperation(root);

            return root;

        }

        private Node<T> RemoveCheckChildsOperation(Node<T> root)
        {
            if (root.Left == null && root.Right == null) return null;
            else if (root.Left == null) return root.Right;
            else if (root.Right == null) return root.Left;

            else
            {
                Node<T> temp = FindMinimum(root.Right);
                root.Key = temp.Key;
                root.Right = Remove(root.Right, temp.Key);
                return root;
            }
        }

        private Node<T> FindMinimum(Node<T> node)
        {
            if (node.Left == null) return node;
            return FindMinimum(node.Left);
        }

        public bool FindItem(T item)
        {
            if (FindItem(_root, item) != null) return true;
            return false;
        }
        private Node<T> FindItem(Node<T> node, T item)
        {
            if (node == null) return null;

            int compare = item.CompareTo(node.Key);

            if (compare < 0) return FindItem(node.Left, item);
            else if (compare > 0) return FindItem(node.Right, item);
            
            return node;
        }

        //private Node<T> GetDeepestRightNode()
        //{
        //    Node<T> node = null;
        //    Queue<Node<T>> nodes = new();
        //    nodes.Enqueue(_root);

        //    while(nodes.Count > 0) 
        //    {
        //        node = nodes.Dequeue();

        //        if (node.Left != null) nodes.Enqueue(node.Left);
        //        if (node.Right != null) nodes.Enqueue(node.Right);
        //    }

        //    return node;
        //}

        //private void DeleteDeepestRightNode(Node<T> deleteNode)
        //{
        //    Queue<Node<T>> nodes = new();
        //    nodes.Enqueue(_root);
        //    Node<T> parentNode = null;
            
        //    while (nodes.Count > 0)
        //    {
        //        Node<T> node = nodes.Dequeue();

        //        if(node == deleteNode) 
        //        {
        //            if(parentNode != null)
        //            {
        //                if (parentNode.Left == node) parentNode.Left = null;
        //                else if (parentNode.Right == node) parentNode.Right = null;
        //            }            
        //            return; 
        //        }

        //        if (node.Right != null)
        //        {
        //            parentNode = node;
        //            nodes.Enqueue(node.Right);
        //        }
                
        //        if (node.Left != null)
        //        {
        //            parentNode = node;
        //            nodes.Enqueue(node.Left);
        //        }

        //    }
        //}

        public int Count()
        {
            if (_root == null) return 0;

            int count = 0;
            Queue<Node<T>> nodes = new();
            nodes.Enqueue(_root);

            while (nodes.Count > 0)
            {
                Node<T> node = nodes.Dequeue();
                count++;

                if (node.Left != null) nodes.Enqueue(node.Left);
                if (node.Right != null) nodes.Enqueue(node.Right);
            }

            return count;
        }

    }
}
