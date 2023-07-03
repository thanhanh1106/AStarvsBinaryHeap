using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarWithBinaryHeap
{
    internal class BinaryHeap<T> where T : IComparable<T>
    {
        List<T> heap;
        public BinaryHeap()
        {
            heap = new List<T>();
        }
        public int Count => heap.Count;
        public void Add(T item)
        {

            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }
        public bool Contains(T item)
        {
            return heap.Contains(item);
        }
        public T TakeRoot()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty!");
            }
            T root = heap[0]; // lấy gốc của cây min heap
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return root;
        }
        void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                // so sánh F của 2 node 
                // nếu node con nhỏ hơn node cha 
                if (heap[index].CompareTo(heap[parentIndex]) < 0)
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else break;
            }
        }
        void HeapifyDown(int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int smallest = index;

            if(leftChild < heap.Count && heap[leftChild].CompareTo(heap[smallest]) < 0)
                smallest = leftChild;
            if(rightChild < heap.Count && heap[rightChild].CompareTo(heap[smallest]) < 0)
                smallest = rightChild;
            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }
        void Swap(int index1, int index2)
        {
            T temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
}
