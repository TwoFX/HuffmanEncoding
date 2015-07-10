using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    static class ExtensionMethods
    {
        public static void Swap<T>(this List<T> coll, int a, int b)
        {
            T c = coll[a];
            coll[a] = coll[b];
            coll[b] = c;
        }
    }
}
