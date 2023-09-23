using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeGenericCollection
{
    public class Node<T>
    {
        private T _key;
        private Node<T> _left;
        private Node<T> _right;

        public T Key { get => _key; set => _key = value; }
        public Node<T> Left { get => _left; set => _left = value; }
        public Node<T> Right { get => _right; set => _right = value; }


        public Node(T item)
        {
            Key = item;
            Left = null;
            Right = null;
        }

    }
}
