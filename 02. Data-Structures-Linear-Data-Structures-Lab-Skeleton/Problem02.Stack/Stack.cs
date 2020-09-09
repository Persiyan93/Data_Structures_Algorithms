namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var  node = _top;
            while (node!= null)
            {
                if (item.Equals(node.Data))
                {
                    return true;
                }
                node = node.NextNode;

            }


            return false;
        }

        public T Peek()
        {
            IsStackEmpty();
            return this._top.Data;
        }

        public T Pop()
        {
            IsStackEmpty();
            var topelement = this._top.Data;
            _top = this._top.NextNode;
            Count--;
            return topelement;

        }

        public void Push(T item)
        {
           
            Node<T> newnode = new Node<T>(item);
            newnode.NextNode = this._top;
            this._top = newnode;
            this.Count++;


        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._top;
            while (current.NextNode!=null)
            {
                yield return current.Data;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
        private void  IsStackEmpty()
        {
            if (_top==null)
            {
                throw new InvalidOperationException("The stack is empty");
            }
        }
    }
}