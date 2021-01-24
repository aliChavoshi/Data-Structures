using System;
using System.Collections.Generic;

namespace Data_Structures.ViewModels
{
    public class Path
    {
        private List<string> nodes = new List<string>();

        public void Add(string node)
        {
            nodes.Add(node);
        }

        public void Print()
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(node);
            }
        }
    }
}