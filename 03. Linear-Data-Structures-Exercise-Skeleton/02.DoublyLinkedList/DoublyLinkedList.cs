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
            Count++;
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
                
                node.Previous = laselElement;
                laselElement.Next = node;
                laselElement = node;

            }
            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();
            return head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();
            return laselElement.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();
            T item = head.Item;
            head = head.Next;
            
            Count--;
            return item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();
            var item = laselElement.Item;
            laselElement = laselElement.Previous;
            
            Count--;
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentelement = head;
            while (currentelement!=null)
            {
                yield return currentelement.Item;
                currentelement = currentelement.Next;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private void EnsureNotEmpty()
        {
            if (head == null)
                throw new InvalidOperationException();
        }
    }
}