using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    class Leaf : Node
    {
        public Leaf(int nodeSize)
        {
            NodeSize = nodeSize;
            Value = new List<int>(NodeSize + 1);
        }

        public Leaf(Leaf leaf)
        {
            NodeSize = leaf.NodeSize;
            Value = new List<int>(leaf.Value);
        }


        public INSERT Insert(int n)
        {
            //TODO
            if (Value.Contains(n))
                return INSERT.DUPLICATE;

            if (Value.Count < NodeSize)
            {
                Value.Add(n);
                Value.Sort();
                return INSERT.SUCCESS;
            } 
            else
            {
                Value.Add(n);
                Value.Sort();
                return INSERT.NEEDSPLIT;

            }

        }

    }
}
