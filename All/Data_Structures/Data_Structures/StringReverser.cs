using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures
{
    public class StringReverser
    {
        public string Reverse(string input)
        {
            if (input == null)
                throw new Exception();

            var stack = new Stack<char>();
            foreach (var c in input.ToCharArray())
                stack.Push(c);

            var reverse = "";
            while (stack.Any())
                reverse += stack.Pop();

            return reverse;
        }
    }

}