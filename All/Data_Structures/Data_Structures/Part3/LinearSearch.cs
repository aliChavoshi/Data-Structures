using System.Linq;

namespace Data_Structures.Part3
{
    public class LinearSearch
    {
        public int Search(int[] numbers, int item)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == item)
                    return i;
            }
            return -1;
        }
    }
}