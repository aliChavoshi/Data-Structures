namespace Data_Structures.Part3
{
    public class TernarySearch
    {
        public int Search(int[] array, int target)
        {
            return Search(array, target, 0, array.Length - 1);
        }

        private int Search(int[] array, int target, int left, int right)
        {
            //base Condition
            if (left > right)
                return -1;
            var partitionSize = (right - left) / 3;
            var mid1 = left + partitionSize;
            var mid2 = right - partitionSize;

            if (array[mid1] == target)
                return mid1;
            if (array[mid2] == target)
                return mid2;
            
            if (target > array[mid2])
            {
                return Search(array, target, mid2 + 1, right);
            }
            if (target < array[mid1])
            {
                return Search(array, target, left, mid1 - 1);
            }
            if (target < array[mid2] && target > array[mid1])
            {
                return Search(array, target, mid1 + 1, mid2 - 1);
            }
            return -1;
        }
    }
}