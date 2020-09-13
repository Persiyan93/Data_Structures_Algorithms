namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Markup;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                EnsureOutOfRangeIndex(index);
                return _items[Count-index-1];
            }
            set
            {
                EnsureOutOfRangeIndex(index);
                _items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            EnsureSizeofArray();
            _items[Count] = item;
            Count++;
            
        }

        public bool Contains(T item)
        {
            foreach (var element in _items)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return (Count - i-1);
                }
            }
            return -1;
           
        }

        public void Insert(int index, T item)
        {
            EnsureOutOfRangeIndex(index);
            EnsureSizeofArray();

            for (int i = Count; i > Count-index-1; i--)
            {
                _items[i ] = _items[i-1];
            }
            Count++;
            _items[Count-index-1] = item;
         
            
        }

        public bool Remove(T item)
        {

            int index = IndexOf(item);
            if (index==-1)
            {
                return false;
            }

            for (int i = Count-index-1; i < Count; i++)
            {
                _items[i] = _items[i + 1];
            }
            Count--;
            return true;
              
        }

        public void RemoveAt(int index)
        {
            EnsureOutOfRangeIndex(index);
            for (int i = Count - index - 1; i < Count; i++)
            {
                _items[i] = _items[i + 1];
            }
            Count--;
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[Count - i - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private void EnsureOutOfRangeIndex(int index)
        {
            if (index<0||index>=Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
        }
        private void EnsureSizeofArray()
        {
            if (_items.Length==Count)
            {
                T[] newArray = new T[2 * Count];
                for (int i = 0; i < _items.Length; i++)
                {
                    newArray[i] = _items[i];
                }
                _items = newArray;
            }
        }
    }
}