using System;
using System.Collections.Generic;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(8);
            tree.Insert(10);

            //should be root first, root = 7
            Queue<int> nodes = tree.LevelOrder();

            while (nodes.Count != 0)
            {
                Console.WriteLine(nodes.Dequeue());
            }
        }
    }
}
