namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.Design;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> lastNode;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node<T>(item);
            if (_head == null)
            {
                _head = node;
                lastNode = _head;

            }
            else
            {
                _head.Previous = node;
                node.NextNode = _head;
                _head = node;

            }
            Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node<T>(item);
            if (_head == null)
            {
                _head = node;
                lastNode = _head;

            }
            else
            {
                lastNode.Previous = lastNode;
                lastNode.NextNode = node;
                lastNode = node;

            }
            Count++;
        }

        public T GetFirst()
        {
            CheckEmptyList();
            return _head.Data;
        }

        public T GetLast()
        {
            CheckEmptyList();
            return lastNode.Data;
        }

        public T RemoveFirst()
        {
            CheckEmptyList();
            T item = _head.Data;
            _head = _head.NextNode;
            Count--;
            return item;
        }

        public T RemoveLast()
        {
            CheckEmptyList();
            T item = lastNode.Data;
            lastNode = lastNode.Previous;
           
            Count--;
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _head;
            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.NextNode;
            }
        }


        private void CheckEmptyList()
        {
            if (_head == null)
            {
                throw new InvalidOperationException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}