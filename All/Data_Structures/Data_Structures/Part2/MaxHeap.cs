using System;

namespace Data_Structures.Part2
{
    public class MaxHeap
    {
        public static void Heapify(int[] array)
        {
            //7/2-1=2=LastParent
            var lastParent = ((array.Length) / 2) - 1;
            for (int i = lastParent; i >= 0; i--)
                Heapify(array, i);
        }
        private static void Heapify(int[] array, int index)
        {
            var largerIndex = index;

            var leftChildIndex = index * 2 + 1;
            if (leftChildIndex < array.Length && array[leftChildIndex] > array[largerIndex])
            {
                largerIndex = leftChildIndex;
            }

            var rightChildIndex = index * 2 + 2;
            if (rightChildIndex < array.Length && array[rightChildIndex] > array[largerIndex])
            {
                largerIndex = rightChildIndex;
            }
            //root grather than children
            if (largerIndex == index)
            {
                return;
            }
            Swap(array, index, largerIndex);
            Heapify(array, largerIndex);
        }
        public static int GetKthLargestItem(int[] array, int k)
        {
            if (array.Length == 0)
                throw new Exception("List Is Empty");

            if (k <= 0)
                throw new Exception("K Grather Than Zero");

            if (k > array.Length)
                throw new Exception("K Is Not Valid");

            var heap = new Heap(5);
            var value = 0;
            foreach (var number in array)
            {
                heap.Insert(number);
            }
            for (var i = 0; i < k; i++)
            {
                value = heap.Remove();
            }
            return value;
        }
        private static void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}