using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures.Part3
{
    public class CountingSort
    {
        public void Sorting(int[] numbers)
        {
            if (numbers.Length == 0)
                return;

            var max = numbers.Max();
            var counts = new int[max + 1];
            foreach (var number in numbers)
            {
                counts[number]++;
            }

            var k = 0;
            for (var i = 0; i < counts.Length; i++)
            {
                var count = counts[i];
                if (count == 0)
                    continue;
                for (var j = 0; j < count; j++)
                    numbers[k++] = i;
            }
        }
    }
}