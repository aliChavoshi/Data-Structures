using System.Linq;

namespace Data_Structures.Part3
{
    public class BinarySearch
    {
        public int SearchRec(int[] array, int target)
        {
            return SearchRec(array, target, 0, array.Length - 1);
        }

        private int SearchRec(int[] array, int target, int left, int right)
        {
            //Base Condition
            if (left > right)
                return -1;

            var middle = (left + right) / 2;

            if (array[middle] == target)
                return middle;

            //Recursion
            return array[middle] > target ?
                SearchRec(array, target, left, middle - 1) :
                SearchRec(array, target, middle + 1, right);
        }

        public int SearchIterate(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;
            while (right >= left)
            {
                var middle = (left + right) / 2;
                
                if (numbers[middle] == target)
                    return middle;
                
                if (numbers[middle] > target)
                    right = middle - 1;
                else
                    left = middle + 1;
            }
            return -1;
        }
    }
}