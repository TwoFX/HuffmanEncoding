using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    public abstract class EncodingTree<T>
    {
        public abstract T Resolve(IEnumerable<bool> path);
    }

    public class EncodingTreeNode<T> : EncodingTree<T>
    {
        private EncodingTree<T> left, right;

        public override T Resolve(IEnumerable<bool> path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            if (!path.Any())
                throw new InvalidOperationException("Path exhausted at non-leaf.");

            return (path.First() ? right : left).Resolve(path.Skip(1));
        }

        public EncodingTreeNode(EncodingTree<T> left, EncodingTree<T> right)
        {
            if (left == null)
                throw new ArgumentNullException("left");

            if (right == null)
                throw new ArgumentNullException("right");

            this.left = left;
            this.right = right;
        }
    }

    public class EncodingTreeLeaf<T> : EncodingTree<T>
    {
        private T symbol;

        public override T Resolve(IEnumerable<bool> path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            if (path.Any())
                throw new InvalidOperationException("Path is non-empty, but a leaf has been reached.");

            return symbol;
        }

        public EncodingTreeLeaf(T symbol)
        {
            this.symbol = symbol;
        }
    }
}
