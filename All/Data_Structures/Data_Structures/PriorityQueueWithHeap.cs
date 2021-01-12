namespace Data_Structures
{
    public class PriorityQueueWithHeap
    {
        private readonly Heap _heap;

        public PriorityQueueWithHeap(int capacity)
        {
            _heap = new Heap(capacity);
        }

        public void Enqueue(int value)
        {
            _heap.Insert(value);
        }

        public int Dequeue()
        {
            return _heap.Remove();
        }

        public bool IsFull()
        {
            return _heap.IsFull();
        }

        public bool IsEmpty()
        {
            return _heap.IsEmpty();
        }
    }
}