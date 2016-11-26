using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    class BTree
    {
        public int Count { get; set; }
        public int IndexCount { get; set; }
        public int LeafCount { get; set; }
        public int NodeSize { get; set; }
        public Node Root { get; set; }
        public Stack<Node> stack { get; set; }
        public bool Trace { get; set; }

        public BTree(int n)
        {

        }





    }
}
