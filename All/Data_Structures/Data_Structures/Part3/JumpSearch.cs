using System;
using System.Linq;

namespace Data_Structures.Part3
{
    public class JumpSearch
    {
        public int Search(int[] array, int target)
        {
            var blockSize = (int)Math.Sqrt(array.Length);
            var start = 0;
            var next = blockSize;//first = 3
            while (start < array.Length && array[next - 1] < target)
            {
                start = next;
                next += blockSize;
                if (next > array.Length)
                    next = array.Length;
            }
            for (int i = start; i < next; i++)
            {
                if (array[i] == target)
                    return i;
            }
            return -1;
        }
    }
}