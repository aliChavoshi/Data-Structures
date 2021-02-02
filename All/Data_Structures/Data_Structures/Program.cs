using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Data_Structures.Part1;
using Data_Structures.Part2;
using Data_Structures.Part3;

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
            /*var graph = new Graph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");

            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("C", "A");
            graph.AddEdge("D", "A");*/

            #endregion

            #region UndirectedGraph

            /*
            var graph = new WeightedGraph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");
            graph.AddNode("F");

            graph.AddEdge("A","B",1);
            graph.AddEdge("A","D",2);
            graph.AddEdge("A","C",3);
            graph.AddEdge("B","D",4);
            graph.AddEdge("C","E",5);
            graph.AddEdge("C","D",6);
            graph.AddEdge("E","F",9);
            graph.AddEdge("F","D",8);
            graph.AddEdge("E","D",7);


            var tree = graph.SpanningTree();
            tree.Print();

            */
            #endregion

            /*var numbers = new int[] { 1, 10, 3, 2 };
            var sorting = new BubbleUp(numbers);
            sorting.Sorting();*/

            var numbers = new int[] {  1,5,6,2,5,4,8,2,1,5,5,1};
            var selectionSort = new CountingSort();
            selectionSort.Sorting(numbers);
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
    }
}