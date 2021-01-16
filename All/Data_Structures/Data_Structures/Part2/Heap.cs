using System;

namespace Data_Structures.Part2
{
    public class Heap
    {
        public Heap(int capacity)
        {
            _items = new int[capacity];
        }
        private readonly int[] _items;
        private int _size;

        public int Max()
        {
            if (IsEmpty())
                throw new Exception("List Is Empty");
                
            return _items[0];
        }
        public void Insert(int value)
        {
            if (IsFull())
                throw new Exception("List Is Full");

            BubbleUp(value);
        }
        public int Remove()
        {
            if (IsEmpty())
                throw new Exception("List Is Empty");

            var root = _items[0];
            _items[0] = _items[--_size];
            _items[_size] = 0;

            BubbleDown();

            return root;
        }
        public bool IsEmpty()
        {
            return _size == 0;
        }
        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = _items[index] >= LeftChild(index);

            if (HasRightChild(index))
                return isValid &= _items[index] >= RightChild(index);

            return isValid;
        }
        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return LeftChild(index) > RightChild(index)
                ? LeftChildIndex(index)
                : RightChildIndex(index);
        }
        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) < _size;
        }
        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) < _size;
        }
        private int LeftChild(int index)
        {
            return _items[LeftChildIndex(index)];
        }
        private int RightChild(int index)
        {
            return _items[RightChildIndex(index)];
        }
        private void BubbleUp(int value)
        {
            _items[_size++] = value;
            var index = _size - 1;
            while (index > 0 && _items[index] > _items[ParentIndex(index)])
            {
                Swap(index, ParentIndex(index));
                index = ParentIndex(index);
            }
        }
        private void BubbleDown()
        {
            var index = 0;
            while (index <= _size && !IsValidParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }
        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }
        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }
        private void Swap(int first, int second)
        {
            var temp = _items[first];
            _items[first] = _items[second];
            _items[second] = temp;
        }
        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        public bool IsFull()
        {
            return _size == _items.Length;
        }
    }
}