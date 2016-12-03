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
        public Index Root { get; set; }
        public Stack<Node> stack { get; set; }
        public bool Trace { get; set; }

        public BTree(int n) // n = nodeSize
        {
            NodeSize = n;                   //set the N-arity of the tree
            Root = new Index(NodeSize);
        }

        //must use the stack to navigate to the appropriate leaf so that 
        //splits can word back up the tree
        public bool AddValue(int n)
        {
            stack = new Stack<Node>(500 / NodeSize);   //make the stack about the right size based on a 500 value tree
            if(Root.Indexes.Count == 0)
            {

                Leaf firstLeaf = new Leaf(NodeSize);
                firstLeaf.Insert(n);
                Root.Insert(n, firstLeaf);
                return true;
            }
            //TODO somehting isnt right here
            else
            {
                Leaf leaf = FindLeaf(n);
                
                INSERT result = leaf.Insert(n);
                if (result == INSERT.SUCCESS)
                {
                    //an unfinished thought. Might need to resort back up the tree if lowest value changed
                    //stack.Pop();
                    //while (stack.Count > 0)
                    //{
                    //    stack.
                    //}
                    return true;

                }
                if (result == INSERT.NEEDSPLIT)
                    SplitLeaf(leaf);

                return true;
            }

        }

        private void SplitLeaf(Leaf leaf)
        {
            Leaf newLeaf = new Leaf(leaf);
            int halfCount = (leaf.Value.Count + 1) / 2;
            Console.WriteLine("halfcount" + halfCount);
            for (int i = 0; i < halfCount; i++)
            {
                Console.WriteLine("i: " + i);
                newLeaf.Insert(leaf.Value[leaf.Value.Count() - 1]); //add last from overloaded leaf
                newLeaf.Value.RemoveAt(0);
                leaf.Value.RemoveAt(leaf.Value.Count - 1);          //remove last from overloaded leaf
            }

            stack.Pop();
            Index parent = (Index)stack.Peek();
            INSERT result = parent.Insert(newLeaf.Value[0], newLeaf);
            if (result == INSERT.NEEDSPLIT)
                SplitIndex(stack.Peek());
            
        }

        private void SplitIndex(Node overFilledNode)
        {
            int halfCount = (overFilledNode.Value.Count + 1) / 2;
            Index newIndex = new Index(NodeSize);
            overFilledNode = (Index)overFilledNode;


            //if stack count = 1 then top of stack = root
            if (stack.Count == 1)
            {
                //do root splitting specific stuff
                Index newRoot = new Index(NodeSize);
                //Console.WriteLine("halfcount" + halfCount);
                
                for (int i = 0; i < halfCount; i++)
                {
                    //Console.WriteLine("i: " + i);
                    newIndex.Insert(overFilledNode.Value[overFilledNode.Value.Count - 1], overFilledNode.Indexes[overFilledNode.Indexes.Count - 1]); //add last from overloaded indexes
                    overFilledNode.Value.RemoveAt(overFilledNode.Value.Count - 1);          //remove last from overloaded index values
                    overFilledNode.Indexes.RemoveAt(overFilledNode.Indexes.Count - 1);      //remove last from overloaded index indexes
                }



                stack.Pop();
                INSERT  result = (newRoot.Insert(overFilledNode.Value[0], overFilledNode));
                        result = (newRoot.Insert(newIndex.Value[0], newIndex));
                Root = newRoot;


            }

            if (stack.Count > 1)
            {
                //do regular index split
                //Console.WriteLine("halfcount" + halfCount);
                for (int i = 0; i < halfCount; i++)
                {
                  //  Console.WriteLine("i: " + i);
                    newIndex.Insert(overFilledNode.Value[overFilledNode.Value.Count - 1], overFilledNode.Indexes[overFilledNode.Indexes.Count - 1]); //add last from overloaded indexes
                    overFilledNode.Value.RemoveAt(overFilledNode.Value.Count - 1);          //remove last from overloaded index values
                    overFilledNode.Indexes.RemoveAt(overFilledNode.Indexes.Count - 1);      //remove last from overloaded index indexes
                }

                stack.Pop();
                INSERT result = ((Index)stack.Peek()).Insert(newIndex.Value[0], newIndex);
                if (result == INSERT.NEEDSPLIT)
                    SplitIndex(stack.Peek());
            }
        }

        //public void DisplayTree()
        //{
        //    stack = new Stack<Node>(500 / NodeSize);   //make the stack about the right size based on a 500 value tree
        //    stack.Push(Root);

        //    while(stack.Count > 0)
        //    {
        //        Console.WriteLine(stack.Peek());
        //        if(stack.Peek() is Index)
        //        {
        //            for (int i = 0; i < stack.Peek().Value.Count; i++)
        //            {
        //                Dig(i);

        //            }
        //        }
        //    }


        //}

            public void DisplayStartup()
        {
            stack = new Stack<Node>(500 / NodeSize);   //make the stack about the right size based on a 500 value tree
            stack.Push(Root);
            //Console.WriteLine(stack.Peek());
            Display(0);
        }

        //private void Display(int i)
        //{
        //    stack.Push(stack.Peek().Indexes[i]);
        //    while (i < stack.Peek().Value.Count)
        //    {
        //        Console.WriteLine(stack.Peek());
        //        Display(i + 1);
        //    }
        //    i = 0;
        //}

        private int Display(int i)
        {
            if(stack.Peek() is Index)
            {

                if (i < stack.Peek().Indexes.Count)
                {
                    Console.WriteLine(stack.Peek());

                    stack.Push(stack.Peek().Indexes[i]);

                    i = Display(i);

                    if (i < stack.Peek().Indexes.Count)
                    {
                        Display(i);

                    }
                }
                
            }
            //stack.peek is leaf
            else
            {
                
                stack.Pop();
                for (int j = 0; j < stack.Peek().Indexes.Count; j++)
                {
                    Console.WriteLine(stack.Peek().Indexes[j]);
                }
                stack.Pop();
                if (i+1 < stack.Peek().Indexes.Count)
                {
                    stack.Push(stack.Peek().Indexes[i + 1]);
                }
            }
            
            return i + 1;
        }

        //private int Dig(int i)
        //{
        //    while (stack.Count > 0)
        //    {
        //        Console.WriteLine(stack.Peek());
        //        if (stack.Peek() is Index)
        //        {
        //            for (int j = 0; j < stack.Peek().Value.Count; j++)
        //            {
        //                Dig(j);

        //            }
        //        }
        //    }
        //}

        private Leaf FindLeaf(int n)
        {
            stack = new Stack<Node>(10);
            stack.Push(Root);

            bool found = false;
            while (stack.Peek() is Index)
            {
                while (!found)
                {
                    if (stack.Peek() is Index)
                    {
                        for (int i = 1; i < stack.Peek().Indexes.Count; i++)
                        {
                            if (n < stack.Peek().Value[i])
                            {
                                if (i == 1 && n < stack.Peek().Value[i - 1])                         
                                    stack.Peek().Value[0] = n;      //this might break it

                                stack.Push(stack.Peek().Indexes[i - 1]);    //push next index to check to stack
                                found = true;
                                break;
                            }
                        }
                        if (!found && n > stack.Peek().Value[stack.Peek().Value.Count - 1])
                        {
                            stack.Push(stack.Peek().Indexes[stack.Peek().Value.Count - 1]); //add to last index
                            found = true;
                        }
                    }
                }
                if (stack.Peek() is Leaf)
                    return (Leaf)stack.Peek();
                else
                    found = false;
            }
            //if (stack.Peek() is Leaf)
            //    return (Leaf)stack.Peek();

            throw new Exception("Find Leaf fail");

        }
    }
}
