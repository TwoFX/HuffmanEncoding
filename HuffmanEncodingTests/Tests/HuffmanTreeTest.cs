using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    using NUnit.Framework;

    [TestFixture]
    class HuffmanTreeTest
    {
        [Test]
        public void HuffmanTreeLeaf()
        {
            HuffmanTreeLeaf<int> a = new HuffmanTreeLeaf<int>(5, 9);
            Assert.AreEqual(9, a.Frequency);
            Assert.AreEqual(5, a.Symbol);
            
            HuffmanTreeLeaf<int> b = new HuffmanTreeLeaf<int>(7, 21);
            Assert.AreEqual(21, b.Frequency);
            Assert.AreEqual(7, b.Symbol);
        }

        [Test]
        public void HuffmanTreeInternal()
        {
            HuffmanTreeLeaf<int> a = new HuffmanTreeLeaf<int>(5, 9);
            HuffmanTreeLeaf<int> b = new HuffmanTreeLeaf<int>(7, 21);
            HuffmanTreeLeaf<int> c = new HuffmanTreeLeaf<int>(2, 125);

            HuffmanTreeInternalNode<int> i1 = new HuffmanTreeInternalNode<int>(a, b);
            Assert.AreEqual(30, i1.Frequency);

            HuffmanTreeInternalNode<int> i2 = new HuffmanTreeInternalNode<int>(c, i1);
            Assert.AreEqual(155, i2.Frequency);
        }

        [Test]
        public void HuffmanTreeCast()
        {
            HuffmanTreeLeaf<int> a = new HuffmanTreeLeaf<int>(5, 9);
            HuffmanTreeLeaf<int> b = new HuffmanTreeLeaf<int>(7, 21);
            HuffmanTreeInternalNode<int> i1 = new HuffmanTreeInternalNode<int>(a, b);

            HuffmanTree<int> castA = a as HuffmanTree<int>;
            Assert.NotNull(castA);
            Assert.AreEqual(9, castA.Frequency);

            HuffmanTree<int> castI1 = i1 as HuffmanTree<int>;
            Assert.NotNull(castI1);
            Assert.AreEqual(30, castI1.Frequency);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HuffmanTreeNegativeFrequency()
        {
            HuffmanTreeLeaf<int> a = new HuffmanTreeLeaf<int>(5, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HuffmanTreeLeftLeafNull()
        {
            HuffmanTreeLeaf<int> a = new HuffmanTreeLeaf<int>(5, 9);
            HuffmanTreeInternalNode<int> i1 = new HuffmanTreeInternalNode<int>(null, a);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HuffmanTreeRightLeafNull()
        {
            HuffmanTreeLeaf<int> a = new HuffmanTreeLeaf<int>(5, 9);
            HuffmanTreeInternalNode<int> i1 = new HuffmanTreeInternalNode<int>(a, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HuffmanTreeCreateSourceNull()
        {
            HuffmanTree<int> a = HuffmanTree<int>.Create(null);
        }

        [Test]
        public void HuffmanTreeCreate1()
        {
            HuffmanTree<char> a = HuffmanTree<char>.Create("this is an example of a huffman tree");
            Assert.AreEqual(36, a.Frequency);
        }
    
    }
}
