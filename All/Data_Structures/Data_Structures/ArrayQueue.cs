using System;

namespace Data_Structures
{
    public class ArrayQueue
    {
        private readonly int[] _items;

        public ArrayQueue(int capacity)
        {
            _items = new int[capacity];
        }
        private int _front;
        private int _rear;
        private int _count;

        public void Enqueue(int value)
        {
            if (_count == _items.Length)
                throw new Exception("Queue Is Full");
            _items[_rear] = value;
            _rear = (_rear + 1) % _items.Length;
            _count++;
        }
        public int Dequeue()
        {
            var item = _items[_front];
            _items[_front] = 0;
            _front = (_front + 1) % _items.Length;
            _count--;
            return item;
        }
        public void PrintIn()
        {
            foreach (var item in _items)
                Console.WriteLine(item);
        }
        public int Peek()
        {
            return _items[_front];
        }
        public bool IsEmpty()
        {
            return _count == 0;
        }
        public bool IsFull()
        {
            return _count == _items.Length;
        }
    }


}