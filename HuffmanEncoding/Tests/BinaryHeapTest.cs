﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    using NUnit.Framework;

    [TestFixture]
    public class BinaryHeapTest
    {
        [Test]
        public void BinaryHeapTest1()
        {
            BinaryHeap<int> h = new BinaryHeap<int>(new[] { 4, 7, 1, 6 });
            Assert.AreEqual(h.Pop(), 1);

            h.Push(5);
            Assert.AreEqual(4, h.Pop());
            Assert.AreEqual(5, h.Pop());
        }

        [Test]
        public void BinaryHeapTest2()
        {
            BinaryHeap<int> h = new BinaryHeap<int>();

            h.Push(2);
            h.Push(1);
            Assert.AreEqual(1, h.Pop());
            Assert.AreEqual(2, h.Pop());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinaryHeapEmpty()
        {
            BinaryHeap<int> h = new BinaryHeap<int>();
            h.Pop();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinaryHeapEmptied()
        {
            BinaryHeap<int> h = new BinaryHeap<int>();
            h.Push(5);
            Assert.AreEqual(5, h.Pop());
            h.Pop();
        }
        
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinaryHeapSourceNull()
        {
            BinaryHeap<int> h = new BinaryHeap<int>(null, null);
        }
    }
}
