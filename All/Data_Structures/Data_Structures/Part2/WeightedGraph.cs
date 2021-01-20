using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using C5;
using Data_Structures.Part1;

namespace Data_Structures.Part2
{
    public class WeightedGraph
    {
        private readonly Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private class Node
        {
            private readonly string _label;
            private readonly List<Edge> _edges = new List<Edge>();
            public Node(string label)
            {
                _label = label;
            }
            public override string ToString()
            {
                return _label;
            }
            public void AddEdge(string toNode, int weight)
            {
                _edges.Add(new Edge(_label, toNode, weight));
            }

            public List<Edge> GetEdges()
            {
                return _edges;
            }
        }
        private class Edge
        {
            private readonly string _from;
            private readonly string _to;
            private readonly int _weight;
            public Edge(string @from, string to, int weight)
            {
                _from = @from;
                _to = to;
                _weight = weight;
            }

            public override string ToString()
            {
                return _from + "->" + _to + " " + $"{_weight}";
            }
        }
        private class NodeEntry
        {
            private readonly Node _node;
            private readonly int _priority;
            public NodeEntry(Node node, int priority)
            {
                _node = node;
                _priority = priority;
            }
            public int GetPriority()
            {
                return _priority;
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
        }

        public void AddEdge(string from, string to, int weight)
        {
            if (!_nodes.TryGetValue(from, out var fromNode))
                throw new Exception("from node not exist");
            if (!_nodes.TryGetValue(to, out var toNode))
                throw new Exception("to node not exist");

            fromNode.AddEdge(to, weight);
            toNode.AddEdge(from, weight);
        }

        public int GetShortestDistance(string from, string to)
        {
            var queue = new IntervalHeap<NodeEntry>();
            queue.Comparer.Compare(null, null);
            return 0;
        }

        public void Print()
        {
            foreach (var node in _nodes.Values)
            {
                var edges = node.GetEdges();
                if (!edges.Any()) continue;
                foreach (var edge in edges)
                {
                    Console.WriteLine(node + " connected to " + edge);
                }
            }
        }
    }
}