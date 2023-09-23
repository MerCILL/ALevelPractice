using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CircularDoublyLinkedList
{
    public sealed class CircularDoubleLinkedList<T> : ICollection<T>
    {
        private Node<T> _first;
        private Node<T> _last;
        private int _count = 0;

        public Node<T>? First => _first;
        public Node<T>? Last => _last;
        public int Count => _count;

        public bool IsReadOnly => false;

        public Node<T> this[int index]
        {
            get
            {
                if (index >= _count || index < 0)
                    throw new ArgumentOutOfRangeException("index");

                Node<T> node = _first;
                for (int i = 0; i < index; i++)
                    node = node.Next;
                return node;
            }
        }

        private void AddFirstItem(T item)
        {
            _first = new Node<T>(item);
            _last = _first;
            _first.Next = _last;
            _first.Previous = _last;

            ++_count;
        }

        public void AddFirst(T item)
        {
            if (_first == null)
            {
                this.AddFirstItem(item);
                return;
            }

            Node<T> newNode = new(item);
            _first.Previous = newNode;
            newNode.Previous = _last;
            newNode.Next = _first;
            _last.Previous = newNode;
            _first = newNode;

            ++_count;
        }

        public void AddLast(T item)
        {
            if(_first == null)
            {
                this.AddFirstItem(item);
                return;
            }

            Node<T> newNode = new(item);
            _last.Next = newNode;
            newNode.Next = _first;
            newNode.Previous = _last;
            _last = newNode;
            _first.Previous = _last;

            ++_count;
        }

        public void AddAfter(Node<T> node, T item)
        {
            ValidationNode(node);

            if (this.FindNode(node.Value) != node)
                throw new InvalidOperationException("Couldn't find node");

            Node<T> newNode = new(item);
            newNode.Next = node.Next;
            node.Next.Previous = newNode;
            newNode.Previous = node;
            node.Next = newNode;

            if (node == _last)
                _last = newNode;

            ++_count;

        }

        public void AddBefore(Node<T> node, T item)
        {
            ValidationNode(node);

            if(this.FindNode(node.Value) != node)
                throw new InvalidOperationException("Couldn't find node");

            Node<T> newNode = new(item);
            node.Previous.Next = newNode;
            newNode.Previous = node.Previous;
            newNode.Next = node;
            node.Previous = newNode;

            if(node == _first)
                _first = newNode;

            ++_count;
        }

        Node<T> FindNode(T value)
        {
            Node<T> current = _first;
            if (current == null) return null;

            do
            {
                if (current.Value.Equals(value)) 
                    return current;
                current = current.Next;
            } while (true);
        }

        void ICollection<T>.Add(T value)
        {
            AddLast(value);
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            return FindNode(item).Value != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null");
            if (arrayIndex < 0 || arrayIndex > array.Length) throw new ArgumentOutOfRangeException("array index");

            Node<T> node = this._first;
            do
            {
                array[arrayIndex++] = node.Value;
                node = node.Next;
            } while (node != _first);
        }

        bool RemoveNode(Node<T> nodeToRemove)
        {
            Node<T> previous = nodeToRemove.Previous;
            previous.Next = nodeToRemove.Next;
            nodeToRemove.Next.Previous = nodeToRemove.Previous;

            if (_first == nodeToRemove)
                _first = nodeToRemove.Next;
            else if (_last == nodeToRemove)
                _last = _last.Previous;

            --_count;
            return true;
        }

        bool ICollection<T>.Remove(T item)
        {
            Node<T> nodeToRemove = this.FindNode(item);
            if (nodeToRemove == null) return false;
            return this.RemoveNode(nodeToRemove);

        }

        public bool RemoveFirst()
        {
            if (_first == null)
                throw new InvalidOperationException("Couldn't find first node");

            return ((ICollection<T>)this).Remove(_first.Value);

        }

        public bool RemoveLast()
        {
            if (_last == null)
                throw new InvalidOperationException("Couldn't find last node");

            return ((ICollection<T>)this).Remove(_last.Value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _first;
            if(current != null)
            {
                do
                {
                    yield return current.Value;
                    current = current.Next;
                } while (current != _first);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ValidationNode(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException("node");
        }

    }
}
