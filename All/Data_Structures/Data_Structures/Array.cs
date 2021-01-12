using System;

namespace Data_Structures
{
    public class Array<T> where T : IComparable
    {
        private T[] _items;
        private int _count;
        public Array(int lenght)
        {
            _items = new T[lenght];
        }

        public void Insert(T item)
        {
            //if the array is full , resize it
            if (_items.Length == _count)
            {
                //Create a new Array (twise the size)
                var newItems = new T[_count * 2];
                //copy all the exisiting items
                for (int i = 0; i < _count; i++)
                    newItems[i] = _items[i];
                //set "Items" to this new array 
                _items = newItems;
            }

            //add the new item at the end
            _items[_count] = item;
            _count++;
        }

        public void RemoveAt(int index)
        {
            //Validate Index
            if (index < 0 || index >= _count)
                throw new ArgumentNullException();
            //Shift the items to the left to fill the hole
            //[10 , (20), 30 , 40]
            //index : 1
            //1 <- 2
            //2 <- 3
            for (var i = index; i < _count; i++)
            {
                if ((i + 1) >= _count)
                {
                    _items.SetValue("", i);
                }
                else
                {
                    _items[i] = _items[i + 1];
                }
            }
            _count--;
        }

        public int IndexOf(T item)
        {
            //if we find it , return index
            //otherwise , retuen -1 
            for (var i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void PrintIn()
        {
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_items[i]);
            }
        }
    }
}