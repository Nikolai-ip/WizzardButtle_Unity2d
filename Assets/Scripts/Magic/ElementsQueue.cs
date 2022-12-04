using System;
using System.Collections;
using System.Collections.Generic;

namespace Magic
{
    public class ElementsQueue<T> : IEnumerable
    {
        private const int MAX_CAPACITY = 3;
        private List<T> _list;

        public int Count
        { get { return _list.Count; } }

        public ElementsQueue()
        {
            _list = new List<T>();
        }

        /// <summary>
        /// Add the element in start the list. Removes 2 element when trying to add 3 elements
        /// </summary>
        /// <param name="elem"></param>
        public void Add(T elem)
        {
            if (_list.Count == MAX_CAPACITY)
            {
                _list.RemoveAt(2);
            }
            _list.Insert(0, elem);
        }

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public T this[int i]
        {
            get { return _list[i]; }
        }

        public override int GetHashCode()
        {
            int _hash = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                _hash += _list[i].GetHashCode() * (10 + (_list.Count * 10));
            }
            return _hash;
        }
        public override bool Equals(object obj)
        {
            if (obj is ElementsQueue<Elements> && _list is List<Elements>)
            {
                return GetHashCode() == obj.GetHashCode();  
            }
            return base.Equals(obj);
            
        }


        public T[] ToArray()
        {
            return _list.ToArray();
        }
    }
}