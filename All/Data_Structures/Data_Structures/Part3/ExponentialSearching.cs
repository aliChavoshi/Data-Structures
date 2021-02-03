namespace Data_Structures.Part3
{
    public class ExponentialSearching
    {
        public int Searching(int[] array, int target)
        {
            var bound = 1;
            while (bound < array.Length && array[bound] < target)
            {
                bound *= 2;
            }

            if (bound > array.Length)
            {
                bound = array.Length-1;
            }
            for (var i = bound / 2; i < bound; i++)
            {
                if (array[i] == target)
                    return i;
            }
            return -1;
        }
    }
}