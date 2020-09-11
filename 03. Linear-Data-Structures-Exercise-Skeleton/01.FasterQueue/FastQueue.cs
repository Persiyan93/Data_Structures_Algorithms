namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> lastElement;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var headItem = this._head.Item;
            var newHead = this._head.Next;
            this._head.Next = null;
            this._head = newHead;

            this.Count--;

            return headItem;
        }

        public void Enqueue(T item)
        {
            var node = new Node<T>(item);
            if (_head==null)
            {
                _head = node;
                lastElement = node;
            }
            else
            {
                lastElement.Next = node;
                lastElement = node;

            }
            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _head;
            while (currentNode!=null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}