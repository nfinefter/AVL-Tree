
using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> root;

        public int Count;

        public Tree ()
        {
            root = null;
            Count = 0;
        }

        public Node<T> Rebalance(Node<T> node)
        {
            if (node.Balance < -1)
            {
                if (node.LeftChild.Balance > 0)
                {
                    node.LeftChild = RotateLeft(node.LeftChild);
                }

                node = RotateRight(node);
            }
            else if (node.Balance > 1)
            {
                if (node.RightChild.Balance < 0)
                {
                    node.RightChild = RotateRight(node.RightChild);
                }

                node = RotateLeft(node);
            }

            return node;
        }
        public int UpdateHeight(Node<T> node)
        {
            if (node.ChildCount == 0) return 1;

            if (node.RightChild == null) return node.LeftChild.Height + 1;

            if (node.LeftChild == null) return node.RightChild.Height + 1;

            if (node.LeftChild.Height > node.RightChild.Height) return node.LeftChild.Height + 1;

            else return node.RightChild.Height + 1;
        }

        public Node<T> RotateLeft(Node<T> node)
        {
            var temp = node.RightChild;
            node.RightChild = temp.LeftChild;
            node.LeftChild = node;
            UpdateHeight(node);
            return temp;
        }

        public Node<T> RotateRight(Node<T> node)
        {
            var temp = node.LeftChild;
            node.LeftChild = temp.RightChild;
            node.RightChild = node;
            UpdateHeight(node);
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

            parent.Height = UpdateHeight(parent);
            return Rebalance(parent);
        }

        public bool Delete(T item)
        {
            int old = Count;
            root = Delete(item, root);
            
            if (Count == old)  return false;
            
            else return true;
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
            parent.Height = UpdateHeight(parent);
            return Rebalance(parent);
        }

        private Node<T> MinNode(Node<T> node)
        {
            if (node.LeftChild == null)
            {
                return node;
            }  
            
            return MinNode(node.LeftChild);
        }

        public Queue<T> PreOrder()
        {
            Queue<T> nodes = new Queue<T>();

            preOrder(root, nodes);

            return nodes;
        }
        private void preOrder(Node<T> node, Queue<T> nodes)
        {
            nodes.Enqueue(node.Value);

            if (node.LeftChild != null)
            {
                preOrder(node.LeftChild, nodes);
            }
            if (node.RightChild != null)
            {
                preOrder(node.RightChild, nodes);
            }
        }
        public Queue<T> InOrder()
        {
            Queue<T> nodes = new Queue<T>();

            inOrder(root, nodes);

            return nodes;
        }
        private void inOrder(Node<T> node, Queue<T> nodes)
        {
            if (node.LeftChild != null)
            {
                inOrder(node.LeftChild, nodes);
            }

            nodes.Enqueue(node.Value);

            if (node.RightChild != null)
            {
                inOrder(node.RightChild, nodes);
            }
        }

        public Queue<T> PostOrder()
        {
            Queue<T> nodes = new Queue<T>();

            postOrder(root, nodes);

            return nodes;
        }

        private void postOrder(Node<T> node, Queue<T> nodes)
        {
            if (node.LeftChild != null)
            {
                postOrder(node.LeftChild, nodes);
            }

            if (node.RightChild != null)
            {
                postOrder(node.RightChild, nodes);
            }

            nodes.Enqueue(node.Value);
        }

    }
}
