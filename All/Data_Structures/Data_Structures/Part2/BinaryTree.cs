using System;
using System.Collections.Generic;

namespace Data_Structures.Part2
{
    public class BinaryTree
    {
        private Node _root;
        private int _count;
        private class Node
        {
            private int _value;
            private Node _leftChild;
            private Node _rightChild;
            public Node(int value, Node leftChild, Node rightChild)
            {
                _value = value;
                _leftChild = leftChild;
                _rightChild = rightChild;
            }

            public int GetValue() => _value;
            public Node GetLeftChild() => _leftChild;
            public Node GetRightChild() => _rightChild;
            public void SetValue(int value) { _value = value; }
            public void SetLeftChild(Node leftChild)
            {
                _leftChild = leftChild;
            }
            public void SetRightChild(Node rightChild)
            {
                _rightChild = rightChild;
            }
        }
        public void Insert(int item)
        {
            var node = new Node(item, null, null);
            if (_root == null)
            {
                _root = node;
                _count++;
                return;
            }
            var current = _root;
            while (true)
            {
                if (item > current.GetValue())
                {
                    if (current.GetRightChild() == null)
                    {
                        current.SetRightChild(node);
                        _count++;
                        break;
                    }
                    current = current.GetRightChild();
                }
                else
                {
                    if (current.GetLeftChild() == null)
                    {
                        current.SetLeftChild(node);
                        _count++;
                        break;
                    }
                    current = current.GetLeftChild();
                }
            }
        }
        public int Count()
        {
            return _count;
        }
        public bool Find(int item)
        {
            if (_root == null)
                return false;

            var current = _root;
            while (true)
            {
                if (current.GetValue() == item)
                {
                    return true;
                }
                if (item > current.GetValue())
                {
                    current = current.GetRightChild();
                    if (current == null)
                    {
                        return false;
                    }
                }
                else
                {
                    current = current.GetLeftChild();
                    if (current == null)
                    {
                        return false;
                    }
                }
            }
        }
        public void TraverseInOrder()
        {
            TraverseInOrder(_root);
        }
        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.GetLeftChild());
            Console.WriteLine(root.GetValue());
            TraverseInOrder(root.GetRightChild());
        }
        public void TraversePostOrder()
        {
            TraversePostOrder(_root);
        }
        private void TraversePostOrder(Node root)
        {
            if (root == null) return;

            TraversePostOrder(root.GetLeftChild());
            TraversePostOrder(root.GetRightChild());
            Console.WriteLine(root.GetValue());
        }
        public void TraversePreOrder()
        {
            TraversePreOrder(_root);
        }
        private void TraversePreOrder(Node root)
        {
            if (root == null) return;

            Console.WriteLine(root.GetValue());
            TraversePreOrder(root.GetLeftChild());
            TraversePreOrder(root.GetRightChild());
        }
        private bool IsLeaf(Node root)
        {
            return root.GetLeftChild() == null && root.GetRightChild() == null;
        }
        public int Height()
        {
            return Height(_root);
        }
        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(Height(root.GetLeftChild()), Height(root.GetRightChild()));
        }
        public int MaxLog()
        {
            if (_root == null)
            {
                return -1;
            }
            var current = _root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.GetRightChild();
            }
            return last.GetValue();
        }
        //O(log n)
        public int MinLog()
        {
            if (_root == null)
            {
                return -1;
            }
            var current = _root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.GetLeftChild();
            }
            return last.GetValue();
        }
        public int Min()
        {
            return Min(_root);
        }
        //O(n)
        private int Min(Node root)
        {
            if (IsLeaf(root))
                return root.GetValue();

            var left = Min(root.GetLeftChild());
            var right = Min(root.GetRightChild());
            //min 3 Values 
            return Math.Min(Math.Min(left, right), root.GetValue());
        }
        public bool EqualsTree(BinaryTree other)
        {
            if (other == null)
                return false;

            return EqualsTree(_root, other._root);
        }
        private bool EqualsTree(Node first, Node second)
        {
            //End Tree
            if (first == null && second == null)
            {
                return true;
            }
            if (first != null && second != null)
            {
                return first.GetValue() == second.GetValue()
                       && EqualsTree(first.GetLeftChild(), second.GetLeftChild())
                       && EqualsTree(first.GetRightChild(), second.GetRightChild());
            }
            return false;
        }
        public bool BinarySearchTree()
        {
            return BinarySearchTree(_root, int.MinValue, int.MaxValue);
        }
        public void SwapRoot()
        {
            var temp = _root.GetLeftChild();
            _root.SetLeftChild(_root.GetRightChild());
            _root.SetRightChild(temp);
        }
        private bool BinarySearchTree(Node root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.GetValue() > max || root.GetValue() < min)
                return false;

            return BinarySearchTree(root.GetLeftChild(), min, root.GetValue() - 1)
                && BinarySearchTree(root.GetRightChild(), root.GetValue() + 1, max);
        }
        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            return GetNodesAtDistance(_root, distance, list);
        }
        private List<int> GetNodesAtDistance(Node root, int distance, List<int> list)
        {
            if (root == null)
            {
                return list;
            }

            if (distance < 0)
                throw new Exception("distance > 0");

            if (distance == 0)
            {
                list.Add(root.GetValue());
                return list;
            }

            GetNodesAtDistance(root.GetLeftChild(), distance - 1, list);
            GetNodesAtDistance(root.GetRightChild(), distance - 1, list);

            return list;
        }
        public void TraverseLevelOrder()
        {
            for (var i = 0; i <= Height(); i++)
            {
                var list = GetNodesAtDistance(i);
                foreach (var i1 in list)
                {
                    Console.WriteLine(i1);
                }
            }
        }
    }
}