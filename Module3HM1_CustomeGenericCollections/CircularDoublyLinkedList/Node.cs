using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularDoublyLinkedList
{
    public sealed class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; internal set; }
        public Node<T> Previous { get; internal set; }

        internal Node(T item)
        {
            Value = item;
        }

    }


}
