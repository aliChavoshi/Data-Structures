﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Data_Structures.Part2;

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

            #region MaxHeap

            /*var numbers = new int[] { 10, 7, 5, 9, 6, 12 };
            var numbers1 = new int[] { 10, 7, 5, 9, 6, 12 };
            MaxHeap.Heapify(numbers);
            var heap = new Heap(6);
            foreach (var number in numbers1)
            {
                heap.Insert(number);
            }*/

            #endregion

            #region Tries

            /*
            var tries = new Trie();
            tries.Insert("car");
            tries.Insert("care");
            tries.Insert("card");
            tries.Insert("careful");
            tries.Insert("egg");
            foreach (var value in tries.FindWordOf(""))
            {
                Console.WriteLine(value);
            }
            */

            #endregion

            #region Graph
            var graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");

            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("C", "A");
            graph.AddEdge("D", "A");

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