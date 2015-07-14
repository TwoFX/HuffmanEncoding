using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    using NUnit.Framework;

    [TestFixture]
    class EncodingTreeTest
    {
        EncodingTree<char> testTree;
        EncodingTreeNode<char> testNode;
        EncodingTreeLeaf<char> testLeaf;

        private IEnumerable<bool> bools(string input)
        {
            return input.Select(c => c == '1');
        }

        [SetUp]
        public void SetUp()
        {
            testNode = new EncodingTreeNode<char>(
                new EncodingTreeNode<char>(
                    new EncodingTreeNode<char>(
                        new EncodingTreeLeaf<char>('a'),
                        new EncodingTreeLeaf<char>('b')),
                    new EncodingTreeLeaf<char>('c')),
                new EncodingTreeLeaf<char>('d'));
            testTree = testNode;
            testLeaf = new EncodingTreeLeaf<char>('a');
        }

        [Test]
        public void EncodingTreeResolve()
        {
            Assert.AreEqual('a', testTree.Resolve(bools("000")));
            Assert.AreEqual('b', testTree.Resolve(bools("001")));
            Assert.AreEqual('c', testTree.Resolve(bools("01")));
            Assert.AreEqual('d', testTree.Resolve(bools("1")));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodingTreeLeafResolvePathNull()
        {
            testLeaf.Resolve(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodingTreeNodeResolvePathNull()
        {
            testNode.Resolve(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EncodingTreeLeafPathNotEmpty()
        {
            testLeaf.Resolve(bools("0"));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EncodingTreeNodeResolvePathTooShort()
        {
            testNode.Resolve(bools("0"));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EncodingTreeNodeResolvePathTooLong()
        {
            testNode.Resolve(bools("10"));
        }
    
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodingTreeNodeLeftNull()
        {
            new EncodingTreeNode<char>(null, new EncodingTreeLeaf<char>('a'));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodingTreeNodeRightNull()
        {
            new EncodingTreeNode<char>(new EncodingTreeLeaf<char>('a'), null);
        }
    }
}
