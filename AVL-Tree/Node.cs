using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree
{
    class Node<T>
    {
        public T item;

        public Node<T> LeftChild;
        public Node<T> RightChild;

        public int ChildCount;
        public int Height;
        public int Balance;


    }
}
