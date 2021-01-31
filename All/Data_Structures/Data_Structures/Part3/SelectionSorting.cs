using System;
using System.Linq;

namespace Data_Structures.Part3
{
    public class SelectionSorting
    {
        private int[] _numbers;

        public SelectionSorting(int[] numbers)
        {
            _numbers = numbers;
        }
        public void Sorting()
        {
            var sorted = new int[5];
            var unsorted = _numbers;
            for (var i = 0; i < _numbers.Length; i++)
            {
                var result = int.MaxValue;
                var m = 0;
                for (var j = 0; j < unsorted.Length; j++)
                {
                    if (unsorted[j] < result)
                    {
                        result = unsorted[j];
                        m = j;
                    }
                }
                unsorted[m] = Int32.MaxValue;
                sorted[i] = result;
            }
            _numbers = sorted;
        }
    }
}