using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTrees
{
    class BTreeDriver
    {
        private static Random r = new Random();
        private static int nodeSize = 11;           //default node size
        private static int numNodes = 0;            //number of nodes in tree
        private static BTree b;                     //tree to be manipulated


        static void Main(string[] args)
        {

            SetNodeSize(3);
            b = new BTree(nodeSize);

            b.AddValue(3);
            b.AddValue(4);
            b.AddValue(5);
            Console.WriteLine("root tostring: \n" + b.Root.ToString());
            Console.WriteLine("indexes 0: \n" + b.Root.Indexes[0]);


            b.AddValue(6);
            Console.WriteLine("after the split");
            Console.WriteLine("root tostring: \n" + b.Root.ToString());
            Console.WriteLine("indexes 0: \n" + b.Root.Indexes[0]);

            Console.WriteLine("indexes 1: \n" + b.Root.Indexes[1]);

            b.AddValue(7);
            b.AddValue(8);

            Console.WriteLine("after the split");
            Console.WriteLine("root tostring: \n" + b.Root.ToString());
            Console.WriteLine("indexes 0: \n" + b.Root.Indexes[0]);

            Console.WriteLine("indexes 1: \n" + b.Root.Indexes[1]);
            Console.WriteLine("indexes 2: \n" + b.Root.Indexes[2]);

            Console.WriteLine("now to split the root");
            b.AddValue(9);
            Console.WriteLine("stack count after add 9: " + b.stack.Count);
            b.AddValue(10);
            Console.WriteLine("stack count after add 10: " + b.stack.Count);


            Console.WriteLine("after the split");
            Console.WriteLine("root tostring: \n" + b.Root.ToString());
            Console.WriteLine("indexes 0: \n" + b.Root.Indexes[0]);

            Console.WriteLine("indexes 1: \n" + b.Root.Indexes[1]);

            Console.WriteLine("second level indexes: ");
            Console.WriteLine("indexes 0: \n" + b.Root.Indexes[0].Indexes[0]);
            Console.WriteLine("indexes 0: \n" + b.Root.Indexes[0].Indexes[1]);

            Console.WriteLine("indexes 1: \n" + b.Root.Indexes[1].Indexes[0]);
            Console.WriteLine("indexes 1: \n" + b.Root.Indexes[1].Indexes[1]);

            b.AddValue(0);
            b.AddValue(1);
            b.AddValue(2);



            Console.WriteLine("indexes 0, 0: \n" + b.Root.Indexes[0].Indexes[0]);
            Console.WriteLine("indexes 0, 1: \n" + b.Root.Indexes[0].Indexes[1]);
            Console.WriteLine("indexes 0, 2: \n" + b.Root.Indexes[0].Indexes[2]);


            b.AddValue(11);
            b.AddValue(12);

            Console.WriteLine("indexes 2: \n" + b.Root.Indexes[1].Indexes[2]);


            b.AddValue(20);
            b.AddValue(21);
            b.AddValue(14);
            b.AddValue(15);


            Console.WriteLine("root tostring: \n" + b.Root);


            Console.WriteLine("indexes 2, 0: \n" + b.Root.Indexes[2].Indexes[0]);
            Console.WriteLine("indexes 2, 1: \n" + b.Root.Indexes[2].Indexes[1]);
            Console.WriteLine("indexes 2, 2: \n" + b.Root.Indexes[2].Indexes[2]);


            Console.WriteLine("now to split the root again");

            b.AddValue(30);
            b.AddValue(31);

            Console.WriteLine("root tostring: \n" + b.Root);

            Console.Clear();
            b.DisplayStartup();


            //b.AddValue(13);
            //b.AddValue(14);






            //List<int> a = new List<int>();
            //a.Add(1);
            //a.Add(2);

            //List<int> c = new List<int>(a);

            //a[0] = 3;
            //a[1] = 4;
            //foreach (var i in a)
            //{
            //    Console.WriteLine(i);
            //}
            //foreach (var i in c)
            //{
            //    Console.WriteLine(i);
            //}

            Console.ReadLine();

        }

        private static void SetNodeSize(int n)
        {
            nodeSize = n;
        }



    }
}
