using System;
using System.Data;

namespace Data_Structures.Part1
{
    public class LinkedList
    {
        private Node _first;
        private Node _last;
        private int _size;
        private class Node
        {
            private readonly int _value;
            internal Node Next;
            public Node(int value) => this._value = value;
            public int GetValue() => _value;
        }
        //isEmpty
        private bool IsEmpty() => _first == null;
        //GetPrevious
        private Node GetPrevious(Node node)
        {
            var current = _first;
            while (current != null)
            {
                if (current.Next == node)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
        //Add First 
        public void AddFirst(int value)
        {
            var node = new Node(value);
            if (IsEmpty())
            {
                _first = _last = node;
            }
            else
            {
                node.Next = _first;
                _first = node;
            }
            _size++;
        }
        //Add Last
        public void AddLast(int value)
        {
            var node = new Node(value);
            if (IsEmpty())
            {
                _first = _last = node;
            }
            else
            {
                _last.Next = node;
                _last = node;
            }
            _size++;
        }
        //Delete First
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new NoNullAllowedException();
            }
            if (_first == _last)
            {
                _first = _last = null;
                _size--;
                return;
            }
            var second = _first.Next;
            _first.Next = null;
            _first = second;
            _size--;
        }
        //Delete Last
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new Exception();
            if (_first == _last)
            {
                _first = _last = null;
                _size--;
                return;
            }
            var previous = GetPrevious(_last);
            _last = previous;
            _last.Next = null;
            _size--;
        }
        //Contains
        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }
        //IndexOf
        public int IndexOf(int value)
        {
            var index = 0;
            var current = _first;
            while (current != null)
            {
                if (current.GetValue() == value)
                {
                    return index;
                }
                index++;
                current = current.Next;
            }
            return -1;
        }
        //Size O(n)
        /*public int Size()
        {
            //O(n)
            var size = 0;
            var current = first;
            if (current==null)
            {
                return 0;
            }
            while (current != null)
            {
                size++;
                current = current.next;
            }
            return size;
        }*/
        //Size O(1)
        public int Size()
        {
            return _size;
        }
        //To Array
        public int[] ToArray()
        {
            var array = new int[_size];
            var index = 0;
            var current = _first;
            while (current != null)
            {
                array[index] = current.GetValue();
                index++;
                current = current.Next;
            }
            return array;
        }
        //To Reverse
        public void ToReverse()
        {
            if (IsEmpty())
                return;

            var privouse = _first;
            var current = _first.Next;
            while (current != null)
            {
                var next = current.Next;
                //[10 <- 20  30]
                //p     c    n
                current.Next = privouse;
                //[10 <- 20  30]
                //       p    c    n
                privouse = current;
                current = next;
            }

            _last = _first;
            _last.Next = null;
            _first = privouse;
        }
        //getKthFromEnd
        public int GetKthFromEnd(int k)
        {
            if (IsEmpty())
                throw new Exception("kthe empty list");
            if (k > _size)
                throw new Exception("The k biger than the size");
            var a = _first;
            var b = _first;
            for (var i = 0; i < k - 1; i++)
            {
                b = b.Next;
                if (b == null)
                    throw new Exception("The k biger than the size");
            }
            while (b != _last)
            {
                a = a.Next;
                b = b.Next;
            }
            return a.GetValue();
        }
    }

}