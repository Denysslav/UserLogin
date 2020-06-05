using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginCustomList.List
{
    class CustomLinkedList<T> : IList<T>
    {
        private ListNode<T> _head;

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public CustomLinkedList()
        {
            _head = null;
            Count = 0;
        }

        public void Add(T item)
        {
            ListNode<T> newNode = new ListNode<T>(item);
            if (null == _head)
            {
                newNode.Prev = null;
                _head = newNode;
                return;
            }


            ListNode<T> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            newNode.Prev = current;
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            ListNode<T> current = _head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Passed array is null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex cannot be negative");
            }

            if (array.Length < Count - arrayIndex)
            {
                throw new ArgumentException("Not enough space in array to perform copy");
            }

            int positionInList = 0, positionInArray = 0;
            ListNode<T> current = _head;
            while (current != null)
            {
                if (positionInList >= arrayIndex)
                {
                    array[positionInArray++] = current.Data;
                }

                current = current.Next;
                positionInList++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] elements = new T[Count];
            CopyTo(elements, 0);

            return new ListElementEnumerator<T>(elements);
        }

        public int IndexOf(T item)
        {
            int currentIndex = 0;
            ListNode<T> current = _head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return currentIndex;
                }

                current = current.Next;
                currentIndex++;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index cannot be negative or greater than total elements count");
            }

            int currentPositionInList = 0, stopPosition = index - 1;

            ListNode<T> current = _head;
            while (current != null)
            {
                if (currentPositionInList == stopPosition)
                {
                    break;
                }

                current = current.Next;
                currentPositionInList++;
            }

            ListNode<T> newNode = new ListNode<T>(item);
            newNode.Next = current.Next;
            current.Next = newNode;
            newNode.Prev = current;
            if (newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }
        }

        public bool Remove(T item)
        {
            ListNode<T> current = _head;
            while (current != null && !current.Data.Equals(item))
            {
                current = current.Next;
            }

            if (current == null)
            {
                return false;
            }

            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }

            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }

            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index cannot be negative or greater than total elements count");
            }

            int currentPositionInList = 0;

            ListNode<T> current = _head;
            while (current != null)
            {
                if (currentPositionInList == index)
                {
                    break;
                }

                current = current.Next;
                currentPositionInList++;
            }

            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }

            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
