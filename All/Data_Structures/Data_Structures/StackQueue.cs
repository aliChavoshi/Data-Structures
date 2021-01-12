using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures
{
    public class StackQueue
    {
        private readonly Stack<int> _stack1;
        private readonly Stack<int> _stack2;
        private int _count;

        public StackQueue(int capacity)
        {
            _stack1 = new Stack<int>(capacity);
            _stack2 = new Stack<int>(capacity);
        }

        public void Enqueue(int value)
        {
            _stack1.Push(value);
            _count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new Exception("List Is Empty");

            PushStack1ToStack2();
            _count--;
            return _stack2.Pop();
        }

        private void PushStack1ToStack2()
        {
            if (!_stack2.Any())
            {
                while (_stack1.Any())
                {
                    _stack2.Push(_stack1.Pop());
                }
            }
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new Exception("List Is Empty");

            PushStack1ToStack2();
            return _stack2.Peek();
        }

        public bool IsEmpty()
        {
            return !_stack1.Any() && !_stack2.Any();
        }
    }

}