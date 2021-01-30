using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures.Part2
{
    public class Trie
    {
        private readonly Node _root = new Node(' ');
        private class Node
        {
            private readonly char _value;
            private readonly Dictionary<char, Node> _children = new Dictionary<char, Node>();
            public bool IsEndOfWord;

            public Node(char value)
            {
                _value = value;
            }
            public void Remove(char chr)
            {
                _children.Remove(chr);
            }
            public bool HasChildren()
            {
                return _children.Any();
            }
            public char GetValue()
            {
                return _value;
            }
            public override string ToString()
            {
                return _value.ToString();
            }
            public bool HasChild(char chr)
            {
                return _children.ContainsKey(chr);
            }
            public void AddChild(char chr)
            {
                _children.Add(chr, new Node(chr));
            }
            public Node GetChild(char chr)
            {
                return _children[chr];
            }
            public Node[] GetChildren()
            {
                return _children.Values.ToArray();
            }
        }

        public void Insert(string word)
        {
            var current = _root;
            foreach (var chr in word)
            {
                if (!current.HasChild(chr))
                {
                    current.AddChild(chr);
                }

                current = current.GetChild(chr);
            }

            current.IsEndOfWord = true;
        }

        public bool LookUp(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            var current = _root;
            foreach (var chr in word)
            {
                if (!current.HasChild(chr))
                    return false;
                current = current.GetChild(chr);
            }
            return current.IsEndOfWord;
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(_root);
        }
        private void TraversePreOrder(Node node)
        {
            //Pre-Order : Visit The Root First
            Console.WriteLine(node.ToString());
            foreach (var child in node.GetChildren())
            {
                TraversePreOrder(child);
            }
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(_root);
        }
        private void TraversePostOrder(Node node)
        {
            foreach (var child in node.GetChildren())
            {
                TraversePostOrder(child);
            }

            Console.WriteLine(node.ToString());
        }

        public void Remove(string word)
        {
            Remove(_root, word, 0);
        }
        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.IsEndOfWord = false;
                return;
            }

            var chr = word.ElementAt(index);
            var child = root.GetChild(chr);
            if (child == null)
                return;

            Remove(child, word, index + 1);
            if (!child.HasChildren() && !child.IsEndOfWord)
            {
                root.Remove(chr);
            }
        }

        public List<string> FindWordOf(string prefix)
        {
            if (prefix == null)
                return new List<string>();

            var words = new List<string>();
            var lastNode = GetLastNodeOf(prefix);
            return FindWordOf(lastNode, prefix, words);
        }
        private List<string> FindWordOf(Node root, string prefix, List<string> words)
        {
            if (root == null)
                return new List<string>();

            if (root.IsEndOfWord)
                words.Add(prefix);

            foreach (var child in root.GetChildren())
            {
                FindWordOf(child, prefix + child.GetValue(), words);
            }

            return words;
        }

        private Node GetLastNodeOf(string prefix)
        {
            var current = _root;
            foreach (var chr in prefix)
            {
                if (!current.HasChild(chr))
                {
                    return null;
                }
                current = current.GetChild(chr);
            }
            return current;
        }
    }
}