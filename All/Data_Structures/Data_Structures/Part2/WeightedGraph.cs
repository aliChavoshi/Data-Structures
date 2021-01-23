using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Data_Structures.Part1;
using Priority_Queue;

namespace Data_Structures.Part2
{
    public class WeightedGraph
    {
        private static readonly Dictionary<string, Node> _nodes = new Dictionary<string, Node>();

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
            public int GetWeight()
            {
                return _weight;
            }
            public override string ToString()
            {
                return _from + "->" + _to + " " + $"{_weight}";
            }
            public Node To()
            {
                if (_nodes.TryGetValue(_to, out var node))
                {
                    return node;
                }

                return null;
            }
        }

        private class NodeEntry : FastPriorityQueueNode
        {
            private readonly Node _node;
            private readonly int _priority;

            public NodeEntry(Node node, int priority)
            {
                _node = node;
                _priority = priority;
            }

            public Node GetNode()
            {
                return _node;
            }
            public int GetPriotiry()
            {
                return _priority;
            }
        }

        private bool HasNode(string label)
        {
            return _nodes.ContainsKey(label);
        }

        private Node Get(string from)
        {
            return _nodes.TryGetValue(@from, out var node) ? node : null;
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

        public int GetShortestDistance(string @from, string to)
        {
            if (!_nodes.TryGetValue(from, out var fromNode))
                throw new Exception("from node not exist");
            if (!_nodes.TryGetValue(to, out var toNode))
                throw new Exception("to node not exist");

            var distances = new Dictionary<Node, int>();
            foreach (var node in _nodes.Values)
            {
                distances.Add(node, int.MaxValue);
            }
            distances.Remove(fromNode);
            distances.Add(fromNode, 0);

            var visited = new HashSet<Node>();

            var queue = new FastPriorityQueue<NodeEntry>(30);
            queue.Enqueue(new NodeEntry(fromNode, 0), 0);

            while (queue.Any())
            {
                var current = queue.Dequeue().GetNode();
                visited.Add(current);

                foreach (var edge in current.GetEdges())
                {
                    var edgeTo = edge.To();
                    if (visited.Contains(edgeTo))
                        continue;
                    var newDistance = distances[current] + edge.GetWeight();
                    if (newDistance >= distances[edgeTo]) continue;
                    distances.Remove(edgeTo);
                    distances.Add(edgeTo, newDistance);
                    queue.Enqueue(new NodeEntry(edgeTo, newDistance), newDistance);
                }
            }
            return distances[_nodes[to]];
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