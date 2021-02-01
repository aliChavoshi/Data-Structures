using System;
using System.Linq;

namespace Data_Structures.Part3
{
    public class SelectionSorting
    {
        private readonly int[] _numbers;

        public SelectionSorting(int[] numbers)
        {
            _numbers = numbers;
        }
        public void Sorting()
        {
            for (var i = 0; i < _numbers.Length; i++)
            {
                var minIndex = FindMinIndex(i);
                Swap(i, minIndex);
            }
        }

        public int FindMinIndex(int i)
        {
            var minIndex = i;
            //j=i For Sorting & Unsorting
            for (var j = i; j < _numbers.Length; j++)
            {
                if (_numbers[j] < _numbers[minIndex])
                {
                    minIndex = j;
                }
            }
            return minIndex;
        }

        public void Swap(int first, int second)
        {
            var temp = _numbers[first];
            _numbers[first] = _numbers[second];
            _numbers[second] = temp;
        }
    }
}