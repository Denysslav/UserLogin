using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginCustomList.List
{
    public class ListElementEnumerator<T> : IEnumerator<T>
    {
        private T[] elements;

        private int currentIndex = 0;

        public ListElementEnumerator(T[] data)
        {
            elements = data;
        }

        public T Current => elements[currentIndex];

        object IEnumerator.Current => elements[currentIndex];

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            currentIndex++;
            if (currentIndex < elements.Length)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            currentIndex = 0;
        }
    }
}
