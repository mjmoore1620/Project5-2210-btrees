using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    class Node : IComparable<Node>
    {
        public int NodeSize { get; set; }
        public List<int> Value { get; set; }
        public List<Node> Indexes { get; set; }

        public Node()
        {

        }

        public Node(int nodeSize)
        {
            NodeSize = nodeSize;
        }

        public override string ToString()
        {
            string toString = "\n";

            toString += "Node Type: " + GetType().ToString().Substring(7) + "\n";
            toString += "Number of values: " + Value.Count + " (Node is " + (Value.Count * 100 / NodeSize) + "% full)\n";
            toString += "Values: \n";

            for (int i = 0; i < Value.Count; i++)
            {
                toString += Value[i] + " ";
            }

            return toString;
        }

        public int CompareTo(Node other)
        {
            return Value[0].CompareTo(other.Value[0]);
        }
    }
}
