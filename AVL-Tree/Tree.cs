
using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> root;

        public int Count;



        public void Insert(T item)
        {
            Count++;
            root = Insert(item, root);
        }
        private Node<T> Insert(T item, Node<T> parent)
        {
            if (parent == null)
            {
                return new Node<T>(item);
            }
            if (item.CompareTo(parent.Value) < 0)
            {
                parent.LeftChild = Insert(item, parent.LeftChild);
            }
            else if (item.CompareTo(parent.Value) >= 0)
            {
                parent.RightChild = Insert(item, parent.RightChild);
            }


            //idk what to write here
            return;
        }

        

        public bool Delete(T item)
        {
            int old = Count;
            root = Delete(item, root);
            if (Count == old)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private Node<T> Delete(T item, Node<T> parent)
        {
            if (parent == null) return null;

            if (item.CompareTo(parent.Value) < 0)
            {
                parent.LeftChild = Delete(item, parent.LeftChild);
            }
            else if (item.CompareTo(parent.Value) > 0)
            {
                parent.RightChild = Delete(item, parent.RightChild);
            }
            else
            {
                if (parent.ChildCount == 2)
                {
                    var temp = MinNode(parent.RightChild);
                    parent.Value = temp.Value;
                    parent.RightChild = Delete(temp.Value, parent.RightChild);
                }
                else
                {
                    Count--;
                    return parent.First;
                }
            }

            //Also dont know what to return
            return;
        }
        private Node<T> MinNode(Node<T> node)
        {
            {
                if (node.LeftChild == null) return node;
                return MinNode(node.LeftChild);
            }
        }
    }
