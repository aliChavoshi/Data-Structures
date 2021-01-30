using System.Collections.Generic;
using System.Linq;

namespace Data_Structures.Part3
{
    public class Sorting
    {
        public Sorting(int[] numbers)
        {
            _numbers = numbers;
        }
        private readonly int[] _numbers;

        public void BubbleUpSorting()
        {
            for (var i = 0; i < _numbers.Length; i++)
            {
                var isSorted = true;
                //no need Compare last item so (-i)
                for (var j = 1; j < _numbers.Length - i; j++)
                {
                    if (_numbers[j - 1] > _numbers[j])
                    {
                        Swap(j - 1, j);
                        isSorted = false;
                    }
                }
                if (isSorted)
                    return;
            }
        }
        private void Swap(int first, int second)
        {
            var item = _numbers[first];
            _numbers[first] = _numbers[second];
            _numbers[second] = item;
        }
    }
}