using System;

namespace Data_Structures.Part1
{
    public class Stack
    {
        private int[] _items = new int[5];
        private int count = 0;
        public void Push(int item)
        {
            if (count == _items.Length)
            {
                throw new Exception("Stack Is Full");
            }
            _items[count] = item;
            count++;
        }
        public int Pop()
        {
            if (count == 0)
                throw new Exception("Stack Is Empty");

            var item = _items[count - 1];
            count--;
            _items[count] = 0;
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
            return _items[count - 1];
        }
    }

}