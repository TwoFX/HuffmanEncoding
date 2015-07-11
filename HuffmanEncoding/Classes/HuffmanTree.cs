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
