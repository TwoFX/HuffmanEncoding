using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    using NUnit.Framework;

    [TestFixture]
    public class PriorityQueueTest
    {
        [Test]
        public void PriorityQueueTest1()
        {
            PriorityQueue<string> a = new PriorityQueue<string>();

            a.Push("World", 7);
            a.Push("Hello", 2);
            Assert.AreEqual("Hello", a.Pop());
            Assert.AreEqual("World", a.Pop());

            a.Push("Hello", 2);
            a.Push("World", 7);
            Assert.AreEqual("Hello", a.Pop());
            Assert.AreEqual("World", a.Pop());
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PriorityQueueTest2()
        {
            PriorityQueue<string> a = new PriorityQueue<string>(new[] { Tuple.Create("Hello", 4), Tuple.Create("World", 9), Tuple.Create("Test", 1) });
            a.Push("Test2", 2);

            Assert.AreEqual("Test", a.Pop());
            int p2;
            Assert.AreEqual("Test2", a.Pop(out p2));
            Assert.AreEqual(2, p2);

            a.Push("First", 0);
            a.Push("Second", 5);
            Assert.AreEqual("First", a.Pop());
            Assert.AreEqual("Hello", a.Pop());
            Assert.AreEqual("Second", a.Pop());
            Assert.AreEqual("World", a.Pop());
            a.Pop();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PriorityQueueEmpty()
        {
            PriorityQueue<string> a = new PriorityQueue<string>();
            a.Pop();
        }
    }
}
