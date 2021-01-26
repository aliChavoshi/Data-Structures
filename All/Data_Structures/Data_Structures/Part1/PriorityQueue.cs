using System;

namespace Data_Structures.Part1
{
    public class PriorityQueue
    {
        private readonly int[] _items;
        private int _count;
        public PriorityQueue(int capacity)
        {
            _items = new int[capacity];
        }
        public void Add(int value)
        {
            if (IsFull())
                throw new Exception("List Is Full");

            var i = ShiftItemsToInsert(value);
            _items[i] = value;
            _count++;
        }
        private int ShiftItemsToInsert(int value)
        {
            int i;
            for (i = _count - 1; i >= 0; i--)
            {
                if (_items[i] > value)
                {
                    _items[i + 1] = _items[i];
                }
                else
                {
                    break;
                }
            }
            return i + 1;
        }
        public int Remove()
        {
            if (IsEmpty())
                throw new Exception("List Is Empty");

            var item = _items[_count - 1];
            _items[_count - 1] = 0;
            _count--;
            return item;
        }
        public bool IsFull()
        {
            return _count == _items.Length;
        }
        public bool IsEmpty()
        {
            return _count == 0;
        }
    }
}