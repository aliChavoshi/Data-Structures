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
                throw new Exception("from node not exist");
            if (!_nodes.TryGetValue(to, out var toNode))
                throw new Exception("to node not exist");
            if (_adjacencyList.TryGetValue(fromNode, out var nodes))
            {
                if (nodes.Any(node => node == toNode))
                {
                    return;
                }
                nodes.Add(toNode);
            }
        }

        public void RemoveNode(string label)
        {
            if (!HasNode(label)) return;
            {
                var node = _nodes[label];
                foreach (var source in _adjacencyList.Keys)
                {
                    var targets = _adjacencyList[source];
                    targets.Remove(node);
                }
                _nodes.Remove(label);
                _adjacencyList.Remove(node);
            }
        }
        public void RemoveEdge(string from, string to)
        {
            if (!_nodes.TryGetValue(from, out var fromNode))
                throw new Exception("from node not exist");
            if (!_nodes.TryGetValue(to, out var toNode))
                throw new Exception("to node not exist");
            if (_adjacencyList.TryGetValue(fromNode, out var nodes))
            {
                nodes.Remove(toNode);
            }
        }

        public List<string> TopologicalSorting()
        {
            var hashSet = new HashSet<Node>();
            var stack = new Stack<Node>();
            foreach (var node in _nodes.Values)
            {
                TopologicalSorting(node, hashSet, stack);
            }
            var sorted = new List<string>();
            while (stack.Any())
            {
                sorted.Add(stack.Pop().ToString());
            }
            return sorted;
        }
        private void TopologicalSorting(Node root, HashSet<Node> visited, Stack<Node> stack)
        {
            if (visited.Contains(root))
                return;

            visited.Add(root);
            if (_adjacencyList.TryGetValue(root, out var nodes))
            {
                foreach (var node in nodes)
                {
                    TopologicalSorting(node, visited, stack);
                }
            }
            stack.Push(root);
        }

        public void TraversalDepthRecursion(string root)
        {
            if (!_nodes.TryGetValue(root, out var node)) return;
            var list = new HashSet<string>();
            TraversalDepthRecursion(node, list);
        }
        private void TraversalDepthRecursion(Node root, HashSet<string> visited)
        {
            Console.WriteLine(root.ToString());
            visited.Add(root.ToString());

            if (_adjacencyList.TryGetValue(root, out var nodes))
                foreach (var node in nodes)
                    if (!visited.Contains(node.ToString()))
                        TraversalDepthRecursion(node, visited);
        }
        public void TraversalDepthIterative(string root)
        {
            if (!_nodes.TryGetValue(root, out var node)) return;

            var visited = new HashSet<string>();
            var stack = new Stack<Node>();
            stack.Push(node);
            while (stack.Any())
            {
                var current = stack.Pop();
                if (visited.Contains(current.ToString()))
                    continue;

                Console.WriteLine(current.ToString());
                visited.Add(current.ToString());

                if (_adjacencyList.TryGetValue(current, out var nodes))
                {
                    foreach (var item in nodes)
                    {
                        stack.Push(item);
                    }
                }
            }
        }
        public void TraversalBreadthIterative(string root)
        {
            if (!_nodes.TryGetValue(root, out var node)) return;

            var visited = new HashSet<string>();
            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (visited.Contains(current.ToString())) continue;

                Console.WriteLine(current.ToString());
                visited.Add(current.ToString());

                if (_adjacencyList.TryGetValue(current, out var nodes))
                {
                    foreach (var item in nodes)
                    {
                        if (!visited.Contains(item.ToString()))
                        {
                            queue.Enqueue(item);
                        }
                    }
                }
            }

        }

        public bool HasCycle()
        {
            var all = new HashSet<Node>();
            foreach (var node in _nodes.Values)
            {
                all.Add(node);
            }
            var visiting = new HashSet<Node>();
            var visited = new HashSet<Node>();
            while (all.Any())
            {
                var current = all.ToArray()[0];
                if (HasCycle(current, all, visiting, visited))
                    return true;
            }
            return false;
        }
        private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
        {
            all.Remove(node);
            visiting.Add(node);

            if (_adjacencyList.TryGetValue(node, out var nodes))
            {
                foreach (var item in nodes)
                {
                    if (visited.Contains(item))
                        continue;

                    if (visiting.Contains(item))
                        return true;

                    if (HasCycle(item, all, visiting, visited))
                        return true;
                }
            }

            visiting.Remove(node);
            visited.Add(node);
            return false;
        }

        public void Print()
        {
            foreach (var source in _adjacencyList.Keys)
            {
                var targets = _adjacencyList[source];
                if (!targets.Any()) continue;
                foreach (var target in targets)
                {
                    Console.WriteLine(source + " --> " + target);
                }
            }
        }
    }
}