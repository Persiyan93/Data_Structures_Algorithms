namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> currentNode;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            CheckIsQueueEmpty();
            var currentNode = this._head;
            while (currentNode!=null)
            {
                if (currentNode.Data.Equals(item))
                {
                    return true;
                }
                currentNode = currentNode.NextNode;
            }
            return false;
        }

        public T Dequeue()
        {
            CheckIsQueueEmpty();
            T item = _head.Data;
            _head = _head.NextNode;
            Count--;
            return item;
        }

        public void Enqueue(T item)
        {
            
            var node = new Node<T>(item);
            if (this._head==null)
            {
                this._head = node;
                this.currentNode = _head;
            }
            else
            {
                this.currentNode.NextNode = node;
                currentNode = node;
            }
            Count++;
        }

        public T Peek()
        {
            CheckIsQueueEmpty();
            return this._head.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this._head;
            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
        private void CheckIsQueueEmpty()
        {
            if (_head==null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }
    }
}