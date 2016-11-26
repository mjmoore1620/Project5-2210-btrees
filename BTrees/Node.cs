using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    class Node
    {
        public int NodeSize { get; set; }
        public List<int> Value { get; set; }

        public Node()
        {

        }

        public Node(int nodeSize)
        {
            NodeSize = nodeSize;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
