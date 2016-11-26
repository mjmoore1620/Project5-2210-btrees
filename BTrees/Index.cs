using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    class Index : Node
    {
        public List<Node> Indexes { get; set; }

        public Index()
        {

        }

        public Index(int n)
        {

        }

        public INSERT Insert(int N, Node node)
        {


            //TODO
            return INSERT.DUPLICATE;
        }

        /// <summary>
        /// Sorts this instance.
        /// </summary>
        private void Sort()
        {
            Indexes.Sort();
        }
    }
}
