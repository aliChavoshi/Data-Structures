using System.Collections.Generic;
using System.Linq;

namespace Data_Structures.Part1
{
    public class ReverseQueueByStack
    {
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