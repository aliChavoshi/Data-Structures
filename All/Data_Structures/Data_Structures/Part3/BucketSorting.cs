using System.Collections.Generic;
using System.Linq;
using Data_Structures.Part1;

namespace Data_Structures.Part3
{
    public class BucketSorting
    {
        public void Sorting(int[] array, int numberOfBickets)
        {
            var buckets = CreateBuckets(array, numberOfBickets);
            var sort = new CountingSort();
            var k = 0;
            foreach (var bucket in buckets)
            {
                if (bucket == null)
                    continue;
                var items = bucket.ToArray();
                items = sort.Sorting(items);
                foreach (var item in items)
                    array[k++] = item;
            }
        }

        private List<LinkedList<int>> CreateBuckets(int[] array, int numberOfBuckets)
        {
            var buckets = new List<LinkedList<int>>(new LinkedList<int>[numberOfBuckets]);
            foreach (var item in array)
            {
                var bucket = item / numberOfBuckets;
                var result = buckets[bucket];
                if (result == null)
                {
                    buckets[bucket] = new LinkedList<int>();
                }
                buckets[bucket].AddLast(item);
            }
            return buckets;
        }
    }
}