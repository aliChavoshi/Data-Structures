using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Data_Structures
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
            public bool IsExistAnyChild()
            {
                return _children.Any();
            }
            public void RemoveChild(char chr)
            {
                _children.Remove(chr);
            }

            public void RemoveChild(string word)
            {
                foreach (var chr in word)
                {
                    RemoveChild(chr);
                }
            }
        }
        public void Insert(string word)
        {
            var currnet = _root;
            foreach (var chr in word)
            {
                if (!currnet.HasChild(chr))
                {
                    currnet.AddChild(chr);
                }
                currnet = currnet.GetChild(chr);
            }
            currnet.IsEndOfWord = true;
        }
        public bool LookUp(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            var current = _root;
            foreach (var chr in word)
            {
                if (!current.HasChild(chr))
                {
                    return false;
                }
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
            var current = _root;
            var pre = _root;
            foreach (var chr in word)
            {
                if (!current.HasChild(chr))
                {
                    return;
                }
                current = current.GetChild(chr);
                if (current.IsEndOfWord && current.IsExistAnyChild())
                {
                    pre = current;
                }
            }
            if (current.IsExistAnyChild())
            { 
                current.IsEndOfWord = false;
                return;
            }
            if (pre != _root)
            {
                pre.RemoveChild(current.GetValue());
            }
            else
            {
                _root.RemoveChild(word);
            }
        }
    }
}