using System;

namespace Data_Structures.Part1
{
    public class Stack
    {
        private readonly int[] _items = new int[5];
        private int _count;
        public void Push(int item)
        {
            if (IsFull())
            {
                throw new Exception("Stack Is Full");
            }
            _items[_count++] = item;
        }
        public bool IsEmpty()
        {
            return _count == 0;
        }
        public bool IsFull()
        {
            return _count == _items.Length;
        }
        public int Pop()
        {
            if (IsEmpty())
                throw new Exception("Stack Is Empty");

            var item = _items[_count - 1];
            _count--;
            _items[_count] = 0;
            return item;
        }
        public void PrintIn()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
        public int Peek()
        {
            return _items[_count - 1];
        }
    }

}