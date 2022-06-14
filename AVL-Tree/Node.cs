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


        public int ChildCount
        {
            get
            {
                int count = 0;
                if (LeftChild != null) count++;
                if (RightChild != null) count++;
                return count;
            }
        }

        public int Height { get; set; }

        public int Balance
        {
            get
            {
                int leftHeight = 0;
                int rightHeight = 0;
                
                if (LeftChild != null)
                {
                    leftHeight = LeftChild.Height;
                }  

                if (RightChild != null)
                {
                    rightHeight = RightChild.Height;
                }

                return rightHeight - leftHeight;
            }
        }



        public Node<T> First
        {
            get
            {
                if (LeftChild != null) return LeftChild;
                if (RightChild != null) return RightChild;
                return null;
            }
        }

        public T Value;

        public Node(T value)
        {
            Value = value;
            Height = 1;
        }

       


    }
}
