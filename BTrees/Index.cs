using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    class Index : Node
    {
        //public List<Node> Indexes { get; set; }

        public Index()
        {

        }

        public Index(int nodeSize)
        {
            NodeSize = nodeSize;   //only n-1 indexes are necessary
            Indexes = new List<Node>(NodeSize + 1);
            Value = new List<int>(NodeSize + 1);

        }

        //TODO
        public INSERT Insert(int n, Node node)//TODO int N
        {
            if (Indexes.Contains(node))
                return INSERT.DUPLICATE;

            if (Indexes.Count < NodeSize)
            {
                Indexes.Add(node);
                Value.Add(n);
                Sort();
                return INSERT.SUCCESS;
            }
            else
            {
                Indexes.Add(node);
                Value.Add(n);
                Sort();
                return INSERT.NEEDSPLIT;

            }

        }

        /// <summary>
        /// Sorts this instance.
        /// </summary>
        private void Sort()
        {
            Value.Sort();
            Indexes.Sort();
        }
    }
}
