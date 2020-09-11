namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> laselElement;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node<T>(item);
            if (head==null)
            {
                head = node;
                laselElement = head;
            }
            else
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }
        }

        public void AddLast(T item)
        {
            var node = new Node<T>(item);
            if (head==null)
            {
                head = node;
                laselElement = head;

            }
            else 
            {
                laselElement.Previous = laselElement;

            }
        }

        public T GetFirst()
        {
            throw new NotImplementedException();
        }

        public T GetLast()
        {
            throw new NotImplementedException();
        }

        public T RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public T RemoveLast()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}