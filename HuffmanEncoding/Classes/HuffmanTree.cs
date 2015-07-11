using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    public abstract class HuffmanTree<TSymbol>
    {
        public abstract int Frequency
        {
            get;
        }

        public static HuffmanTree<TSymbol> Create(IEnumerable<TSymbol> source, IEqualityComparer<TSymbol> comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            IEqualityComparer<TSymbol> comp = comparer ?? EqualityComparer<TSymbol>.Default;

            Dictionary<TSymbol, int> freq = new Dictionary<TSymbol, int>(comp);

            foreach (TSymbol item in source)
            {
                int f = 1;
                if (freq.ContainsKey(item))
                    f = freq[item] + 1;
                freq[item] = f; 
            }

            PriorityQueue<HuffmanTree<TSymbol>> pq = new PriorityQueue<HuffmanTree<TSymbol>>(
                freq.Select(kvp => Tuple.Create((HuffmanTree<TSymbol>)new HuffmanTreeLeaf<TSymbol>(kvp.Key, kvp.Value), kvp.Value)));

            while (pq.Size >= 2)
            {
                var a = pq.Pop();
                var b = pq.Pop();

                var newNode = new HuffmanTreeInternalNode<TSymbol>(a, b);

                pq.Push(newNode, newNode.Frequency);
            }

            return pq.Pop();
        }
    }

    public class HuffmanTreeInternalNode<TSymbol> : HuffmanTree<TSymbol>
    {
        private HuffmanTree<TSymbol> left, right;

        public override int Frequency
        {
            get { return left.Frequency + right.Frequency; }
        }

        public HuffmanTreeInternalNode(HuffmanTree<TSymbol> left, HuffmanTree<TSymbol> right)
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            this.left = left;
            this.right = right;
        }
    }

    public class HuffmanTreeLeaf<TSymbol> : HuffmanTree<TSymbol>
    {
        private TSymbol symbol;
        private int frequency;

        public override int Frequency
        {
            get { return frequency; }
        }

        public TSymbol Symbol
        {
            get { return symbol; }
        }

        public HuffmanTreeLeaf(TSymbol symbol, int frequency)
        {
            if (frequency < 0)
                throw new ArgumentOutOfRangeException("frequency");

            this.symbol = symbol;
            this.frequency = frequency;
        }
    }
}
