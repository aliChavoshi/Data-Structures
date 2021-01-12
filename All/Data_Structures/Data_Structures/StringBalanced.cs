using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures
{
    public class StringBalanced
    {
        private List<string> _leftBrackets = new List<string>() { "(", "[", "<", "{" };
        private List<string> _rightBrackets = new List<string>() { ")", "]", ">", "}" };
        public bool IsBalanced(string input)
        {
            var stack = new Stack<char>();
            foreach (var ch in input.ToCharArray())
            {
                var str = Convert.ToString(ch);
                if (IsLeft(str))
                {
                    stack.Push(ch);
                }
                if (IsRight(str))
                {
                    //Stack Is Empty ")"
                    if (!stack.Any())
                    {
                        return false;
                    }
                    var left = stack.Pop().ToString();
                    if (!IsMatched(left, str))
                    {
                        return false;
                    }
                }
            }
            return !stack.Any();
        }
        private bool IsMatched(string left, string right)
        {
            return _leftBrackets.IndexOf(left) == _rightBrackets.IndexOf(right);
        }
        private bool IsLeft(string str)
        {
            return _leftBrackets.Contains(str);
        }
        private bool IsRight(string str)
        {
            return _rightBrackets.Contains(str);
        }
    }

}