
using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> root;

        public int Count;

        
        public void Rotate(Node<T> node)
        {
            if (node.Balance == 0) return;

            if (node.Balance > 1)
            {
                node.RightChild.LeftChild = node;
                return;
            }
            if (node.Balance < 1)
            { 
                node.LeftChild.RightChild = node;
                return;
            }
            
        }

        public void Rebalance(Node<T> node)
        {
            if (node.Balance == 0)
            {
                return;
            }

            if (node.Balance > 1)
            {
                if (node.RightChild.Balance != node.Balance)
                {
                    RotateRight(node);
                }

                RotateLeft(node);
            }
            if (node.Balance < 1)
            {
                if (node.LeftChild.Balance != node.Balance)
                {
                    RotateLeft(node);
                }

                RotateRight(node);
            }
        }

        public Node<T> RotateLeft(Node<T> node)
        {
            var temp = node.RightChild;
            node.RightChild = temp.LeftChild;
            node.LeftChild = temp;
            return temp;
        }

        public Node<T> RotateRight(Node<T> node)
        {
            var temp = node.LeftChild;
            node.LeftChild = temp.RightChild;
            node.RightChild = temp;
            return temp;
        }
   
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
