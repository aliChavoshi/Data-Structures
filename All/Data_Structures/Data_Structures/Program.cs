using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            #region HEAP

            /*var numbers = new int[5] { 5, 7, 10, 16, 9 };
            var heap = new Heap(5);
            foreach (var number in numbers)
            {
                heap.Insert(number);
            }

            for (var i = numbers.Length - 1; i >= 0; i--)
            {
                numbers[i] = heap.Remove();
            }*/

            #endregion

            
        }
        static int Hash(string value)
        {
            var hash = 0;
            foreach (var chr in value)
            {
                hash += chr;
            }
            return hash;
        }
        public static void Reverse(Queue<int> queues)
        {
            var stacks = new Stack<int>();
            while (queues.Any())
            {
                stacks.Push(queues.Dequeue());
            }
            while (stacks.Any())
            {
                queues.Enqueue(stacks.Pop());
            }
        }
    }
}
