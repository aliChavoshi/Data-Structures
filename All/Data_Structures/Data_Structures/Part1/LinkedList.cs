using System;
using System.Data;

namespace Data_Structures.Part1
{
    public class LinkedList
    {
        private Node first;
        private Node last;
        private int size;
        private class Node
        {
            private int value;
            internal Node next;
            public Node(int value) => this.value = value;
            public int GetValue() => value;
        }
        //isEmpty
        private bool IsEmpty() => first == null;
        //GetPrevious
        private Node GetPrevious(Node node)
        {
            var current = first;
            while (current != null)
            {
                if (current.next == node)
                {
                    return current;
                }
                current = current.next;
            }
            return null;
        }
        //Add First 
        public void AddFirst(int value)
        {
            var node = new Node(value);
            if (IsEmpty())
            {
                first = last = node;
            }
            else
            {
                node.next = first;
                first = node;
            }
            size++;
        }
        //Add Last
        public void AddLast(int value)
        {
            var node = new Node(value);
            if (IsEmpty())
            {
                first = last = node;
            }
            else
            {
                last.next = node;
                last = node;
            }
            size++;
        }
        //Delete First
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new NoNullAllowedException();
            }
            if (first == last)
            {
                first = last = null;
                size--;
                return;
            }
            var second = first.next;
            first.next = null;
            first = second;
            size--;
        }
        //Delete Last
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            if (first == last)
            {
                first = last = null;
                size--;
                return;
            }
            var previous = GetPrevious(last);
            last = previous;
            last.next = null;
            size--;
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
            var current = first;
            while (current != null)
            {
                if (current.GetValue() == value)
                {
                    return index;
                }
                index++;
                current = current.next;
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
            return size;
        }
        //To Array
        public int[] ToArray()
        {
            var array = new int[size];
            var index = 0;
            var current = first;
            while (current != null)
            {
                array[index] = current.GetValue();
                index++;
                current = current.next;
            }
            return array;
        }
        //To Reverse
        public void ToReverse()
        {
            if (IsEmpty())
                return;

            var privouse = first;
            var current = first.next;
            while (current != null)
            {
                var next = current.next;
                //[10 <- 20  30]
                //p     c    n
                current.next = privouse;
                //[10 <- 20  30]
                //       p    c    n
                privouse = current;
                current = next;
            }

            last = first;
            last.next = null;
            first = privouse;
        }
        //getKthFromEnd
        public int GetKthFromEnd(int k)
        {
            if (IsEmpty())
                throw new Exception("kthe empty list");
            if (k > size)
                throw new Exception("The k biger than the size");
            var a = first;
            var b = first;
            for (var i = 0; i < k - 1; i++)
            {
                b = b.next;
                if (b == null)
                    throw new Exception("The k biger than the size");
            }
            while (b != last)
            {
                a = a.next;
                b = b.next;
            }
            return a.GetValue();
        }
    }

}