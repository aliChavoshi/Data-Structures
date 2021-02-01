using System.Linq;

namespace Data_Structures.Part3
{
    public class MergeSorting
    {
        public void Sorting(int[] array)
        {
            //base Condition
            if (array.Length < 2)
                return;

            //Divide this array into half
            var middle = array.Length / 2;
            var left = array.Take(middle).ToArray();
            var right = array.Skip(middle).ToArray();

            //sort each half
            Sorting(left);
            Sorting(right);

            //merge the result
            Merg(left, right, array);
        }

        private void Merg(int[] left, int[] right, int[] result)
        {
            //i = left , //j= right , //k = result
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }
            while (i < left.Length)
                result[k++] = left[i++];

            while (j < right.Length)
                result[k++] = right[j++];
        }
    }
}