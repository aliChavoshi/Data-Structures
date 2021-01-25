using System;
using System.Collections.Generic;
using System.Linq;
using Data_Structures.ViewModels;
using Priority_Queue;

namespace Data_Structures.Part2
{
    public class WeightedGraph
    {
        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();

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
            public string GetLabel()
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
            public Edge(string from, string to, int weight)
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
                return _from + "->" + _to + " : " + $"{_weight}";
            }
            public string To()
            {
                return _to;
            }
            public string From()
            {
                return _from;
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

        private bool containsNode(string label)
        {
            return _nodes.ContainsKey(label);
        }

        private Node Get(string label)
        {
            return _nodes.TryGetValue(label, out var node) ? node : null;
        }

        public void AddNode(string label)
        {
            var node = new Node(label);
            if (containsNode(label)) return;

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

            var queue = new FastPriorityQueue<NodeEntry>(10);
            queue.Enqueue(node: new NodeEntry(fromNode, 0), priority: 0);

            while (queue.Any())
            {
                var current = queue.Dequeue().GetNode();
                visited.Add(current);

                foreach (var edge in current.GetEdges())
                {
                    var edgeTo = Get(edge.To());
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

        public Path GetShortestPath(string from, string to)
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

            var privouseNode = new Dictionary<Node, Node>();

            var queue = new FastPriorityQueue<NodeEntry>(10);
            queue.Enqueue(node: new NodeEntry(fromNode, 0), priority: 0);

            while (queue.Any())
            {
                var current = queue.Dequeue().GetNode();
                visited.Add(current);

                foreach (var edge in current.GetEdges())
                {
                    var edgeTo = Get(edge.To());
                    if (visited.Contains(edgeTo))
                        continue;

                    var newDistance = distances[current] + edge.GetWeight();
                    if (newDistance >= distances[edgeTo]) continue;

                    distances.Remove(edgeTo);
                    distances.Add(edgeTo, newDistance);
                    if (privouseNode.TryGetValue(edgeTo, out var currentNode))
                    {
                        privouseNode.Remove(edgeTo);
                    }
                    privouseNode.Add(edgeTo, current);
                    queue.Enqueue(new NodeEntry(edgeTo, newDistance), newDistance);
                }
            }
            return BuildPath(privouseNode, toNode);
        }

        private Path BuildPath(Dictionary<Node, Node> privouseNode, Node toNode)
        {
            var stack = new Stack<Node>();
            stack.Push(toNode);//E
            if (privouseNode.TryGetValue(toNode, out var privious))//B
            {

            }
            while (privious != null)
            {
                stack.Push(privious);//B
                if (privouseNode.TryGetValue(privious, out var node))//A
                {

                }
                privious = node;
            }

            var path = new Path();
            while (stack.Any())
            {
                path.Add(stack.Pop().ToString());
            }
            return path;
        }

        public bool HasCycle()
        {
            var visited = new HashSet<Node>();
            foreach (var node in _nodes.Values)
            {
                if (!visited.Contains(node) && HasCycle(node, null, visited))
                {
                    return true;
                }
            }
            return false;
        }

        public int GetCountNode()
        {
            return _nodes.Count;
        }

        private bool HasCycle(Node node, Node parent, HashSet<Node> visited)
        {
            visited.Add(node);
            foreach (var edge in node.GetEdges())
            {
                var edgeTo = Get(edge.To());
                //no visit parent
                if (edgeTo == parent)
                    continue;
                if (visited.Contains(edgeTo) || HasCycle(edgeTo, node, visited))
                    return true;
            }
            return false;
        }

        public WeightedGraph SpanningTree()
        {
            var tree = new WeightedGraph();
            var edges = new SimplePriorityQueue<Edge, int>();
            var startNode = _nodes.Values.First();
            //C : min,B
            foreach (var edge in startNode.GetEdges())
            {
                edges.Enqueue(edge, edge.GetWeight());
            }
            //A
            tree.AddNode(startNode.GetLabel());

            while (tree.GetCountNode() < GetCountNode())
            {
                //C
                var minEdge = edges.Dequeue();
                if (tree.containsNode(minEdge.To()))
                    continue;
                //C
                tree.AddNode(minEdge.To());
                //A->C
                tree.AddEdge(minEdge.From(), minEdge.To(), minEdge.GetWeight());
                //C
                var nextNode = Get(minEdge.To());

                foreach (var edge in nextNode.GetEdges())
                {
                    if (!tree.containsNode(edge.To()))
                    {
                        edges.Enqueue(edge, edge.GetWeight());
                    }
                }
            }
            return tree;
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