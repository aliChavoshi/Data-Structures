using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Data_Structures.Part2
{
    public class Graph
    {
        private readonly Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private readonly Dictionary<Node, List<Node>> _adjacencyList = new Dictionary<Node, List<Node>>();
        private class Node
        {
            private readonly string _label;
            public Node(string label)
            {
                _label = label;
            }
            public override string ToString()
            {
                return _label;
            }
        }
        private bool HasNode(string label)
        {
            return _nodes.ContainsKey(label);
        }

        public void AddNode(string label)
        {
            var node = new Node(label);
            if (HasNode(label)) return;

            _nodes.Add(label, node);
            _adjacencyList.Add(node, new List<Node>());
        }
        public void AddEdge(string from, string to)
        {
            if (!_nodes.TryGetValue(from, out var fromNode))
            {
                throw new Exception("from node not exist");
            }
            if (!_nodes.TryGetValue(to, out var toNode))
            {
                throw new Exception("to node not exist");
            }
            if (_adjacencyList.TryGetValue(fromNode, out var nodes))
            {
                if (nodes.Any(node => node == toNode))
                {
                    return;
                }
                nodes.Add(toNode);
            }
        }

        public void Print()
        {
            foreach (var source in _adjacencyList.Keys)
            {
                var targets = _adjacencyList[source];
                if (!targets.Any()) continue;
                foreach (var target in targets)
                {
                    Console.WriteLine(source + " connected To " + target);
                }
            }
        }
    }
}