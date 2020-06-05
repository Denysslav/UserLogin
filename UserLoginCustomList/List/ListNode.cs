using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginCustomList.List
{
    internal class ListNode<T>
    {
        internal T Data;

        internal ListNode<T> Prev;

        internal ListNode<T> Next;

        public ListNode(T t)
        {
            Data = t;
            Prev = null;
            Next = null;
        }
    }
}
