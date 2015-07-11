using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    public class PriorityQueue<T>
    {
        private class PriorityComparer<TPayload> : IComparer<Tuple<TPayload, int>>
        {
            private static IComparer<int> comp = Comparer<int>.Default;

            public int Compare(Tuple<TPayload, int> first, Tuple<TPayload, int> second)
            {
                return comp.Compare(first.Item2, second.Item2);
            }
        }

        private BinaryHeap<Tuple<T, int>> underlying;

        public PriorityQueue()
            : this(Enumerable.Empty<Tuple<T, int>>())
        {
        }

        public PriorityQueue(IEnumerable<Tuple<T, int>> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            underlying = new BinaryHeap<Tuple<T, int>>(source, new PriorityComparer<T>());
        }

        public int Size
        {
            get { return underlying.Size; }
        }

        public void Push(T value, int priority)
        {
            underlying.Push(new Tuple<T, int>(value, priority));
        }

        public T Pop()
        {
            return underlying.Pop().Item1;
        }

        public T Pop(out int priority)
        {
            Tuple<T, int> pair = underlying.Pop();
            priority = pair.Item2;
            return pair.Item1;
        }
    }
}
