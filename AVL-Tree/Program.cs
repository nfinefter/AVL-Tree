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
            tree.Insert(5);

            Queue<int> nodes = new Queue<int>();

            nodes = tree.PreOrder();

            for (int i = 0; i < nodes.Count; i++)
            {
                Console.WriteLine(nodes.Dequeue());
            }
        }
    }
}
