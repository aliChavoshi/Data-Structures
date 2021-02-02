using System.Linq;

namespace Data_Structures.Part3
{
    public class QuickSort
    {
        public void Sorting(int[] numbers)
        {
            Sorting(numbers, 0, numbers.Length - 1);
        }
        private void Sorting(int[] numbers, int start, int end)
        {
            //Base Condition 
            if (start >= end)
                return;
            //Partitioning
            var boundary = Partition(numbers, start, end);
            //Sort Left
            Sorting(numbers, start, boundary - 1);
            //Sort Right
            Sorting(numbers, boundary + 1, end);
        }

        private int Partition(int[] numbers, int start, int end)
        {
            var pivot = numbers[end];
            var boundary = start - 1;
            for (var i = start; i <= end; i++)
            {
                if (numbers[i] <= pivot)
                    //b++ = ++b
                    Swap(numbers, i, ++boundary);
            }
            return boundary;
        }
        private void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}