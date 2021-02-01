namespace Data_Structures.Part3
{
    public class InsertionSort
    {
        private readonly int[] _numbers;

        public InsertionSort(int[] numbers)
        {
            _numbers = numbers;
        }

        public void Sorting()
        {
            for (var i = 0; i < _numbers.Length; i++)
            {
                var current = _numbers[i];
                var index = i;
                for (var j = i; j >= 0; j--)
                {
                    if (_numbers[j] > _numbers[index])
                    {
                        _numbers[index] = _numbers[j];
                        _numbers[j] = current;
                        index--;
                    }
                }
            }
        }
    }
}