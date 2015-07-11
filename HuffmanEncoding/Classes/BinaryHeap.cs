using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace HuffmanEncoding
{
    public class BinaryHeap<T> : IEnumerable<T>
    {
        private List<T> underlying;
        private IComparer<T> comp;

        public BinaryHeap(IComparer<T> comp = null)
            : this(Enumerable.Empty<T>(), comp)
        {
        }

        public BinaryHeap(IEnumerable<T> source, IComparer<T> comp = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            underlying = new List<T>(source);
            this.comp = comp ?? Comparer<T>.Default;

            this.fullBalance();
        }

        public int Size
        {
            get { return underlying.Count; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return underlying.GetEnumerator();
        }

        public T Pop()
        {
            if (underlying.Count == 0)
                throw new InvalidOperationException("Heap is empty");

            T store = underlying[0];
            underlying[0] = underlying[underlying.Count - 1];
            underlying.RemoveAt(underlying.Count - 1);
            balanceDown();
            return store;
        }

        public void Push(T value)
        {
            underlying.Add(value);
            balanceUp(underlying.Count - 1);
        }

        private void balanceUp(int index = 0)
        {
            if (index == 0 || underlying.Count == 0)
                return;

            int parent = (int)Math.Floor((index - 1) / 2.0);

            if (comp.Compare(underlying[index], underlying[parent]) < 0)
            {
                underlying.Swap(index, parent);
                balanceUp(parent);
            }
        }

        private void balanceDown(int index = 0)
        {
            if (underlying.Count == 0)
                return;

            int largestIndex = new[] { index, 2 * index + 1, 2 * index + 2 }
                .Where(ind => ind < underlying.Count)
                .MinBy(ind => underlying[ind], this.comp);

            if (largestIndex != index)
            {
                underlying.Swap(largestIndex, index);
                balanceDown(largestIndex);
            }
        }

        private void fullBalance(int index = 0)
        {
            for (int i = underlying.Count / 2 - 1; i >= 0; i--)
            {
                balanceDown(i);
            }
        }
    }
}
