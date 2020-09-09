namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Cryptography.X509Certificates;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;
        

        public int Count { get; private set; }

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return _items[index];
            }
            set
            {
                CheckIndex(index);
                _items[index] = value;
            }
        }

       

        public void Add(T item)
        {
            if (this.Count==this._items.Length)
            {
                Resize();
            }
            _items[Count++] = item;
        }

        public bool Contains(T item)
        {
            return  _items.Contains(item);
        }


        public int IndexOf(T item)
        {

            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);
            if (_items.Length==Count)
            {
                Resize();
            }
            for (int i = index; i <=Count; i++)
            {
                _items[i + 1] = _items[i];
            }
            _items[index] = item;
            Count++;

        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    for (int j = i; j < Count-1; j++)
                    {
                        _items[j] = _items[j + 1];
                    }
                    Count--;
                    return true;

                }
               
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);
            for (int i = index; i < Count; i++)
            {
                _items[i] = _items[i + 1];
            }
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
        }
        private void Resize()
        {
            T[] temp = new T[2 * this._items.Length];
            for (int i = 0; i < _items.Length; i++)
            {
                temp[i] = _items[i];

            }
            _items = temp;
        }
    }
}