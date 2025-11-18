using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInarySearchTree
{
    class BinarySearchTree
    {
        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }
        public void Display(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.key.ToString() + "");
                
            }
            else
            {
                Console.WriteLine("null" + "");
            }
        }

        public void Process(Node node)
        {
            Display(node);
        }
        public void PreOrder(Node aRoot)
        {
            if (aRoot != null)
            {
                Process(aRoot);
                PreOrder(aRoot.left);
                PreOrder(aRoot.right);
            }
        }
        public void InOrder(Node aRoot)
        {
            if (aRoot != null)
            {
                InOrder(aRoot.left);
                Process(aRoot);
                InOrder(aRoot.right);
            }
        }
        public void PostOrder(Node aRoot)
        {
            if (aRoot != null)
            {
                PostOrder(aRoot.left);
                PostOrder(aRoot.right);
                Process(aRoot);
            }
        }
        public void CountAndSumAllNodes(Node aRoot,ref int count,ref int sum)
        {
            if (aRoot != null)
            {
                count++;
                sum += aRoot.key;
                CountAndSumAllNodes(aRoot.left, ref count, ref sum);
                CountAndSumAllNodes(aRoot.right, ref count, ref sum);
            }
        }
        public int CalTreeHeight(Node aRoot)
        {
            if (aRoot == null)
                return -1;
            int h_left = CalTreeHeight(aRoot.left);
            int h_right = CalTreeHeight(aRoot.right);
            return ((h_left > h_right) ? h_left : h_right) + 1;
        }
        public Node Search(int x)
        {
            Node curNode = root;
            while (x != curNode.key)
            {
                if (x < curNode.key)
                    curNode = curNode.left;
                else
                    curNode = curNode.right;
                if (curNode == null) return null;
            }
            return curNode;
        }
        public int FindMax(Node aRoot)
        {
            int Max = aRoot.key;
            if (aRoot.right == null)
                return Max;
            else
                return FindMax(aRoot.right);
        }
        public int FindMin(Node aRoot)
        {
            int Min = aRoot.key;
            if (aRoot.left == null)
                return Min;
            else
                return FindMin(aRoot.left);
        }
        public bool Add(int x)
        {
            bool result = true;
            Node newNode = new Node(x);
            if (root == null)
            {
                root = newNode;
                return result;
            }
            Node curNode = root;
            Node parentNode;
            while (true)
            {
                parentNode = curNode;
                if (x == curNode.key)
                {
                    result = false;
                    break;
                }
                if (x < curNode.key)
                {
                    curNode = curNode.left;
                    if (curNode == null)
                    {
                        parentNode.left = newNode;
                        break;
                    }

                }
                else
                {
                    curNode = curNode.right;
                    if (curNode == null)
                    {
                        parentNode.right = newNode;
                        break;
                    }
                }
            }
            return result;
        }
        public Node GetSubsNode(Node removeNode)
        {
            Node subsParent = removeNode;
            Node subsNode = removeNode;
            Node curNode = removeNode.right;
            while (curNode != null)
            {
                subsParent = subsNode;
                subsNode = curNode;
                curNode = curNode.left;

            }
            if (subsNode != removeNode.right)
            {
                subsParent.left = removeNode.right;
                subsNode.right = removeNode.right;
            }
            return subsNode;
        }
        public bool Remove(int x)
        {
            Node curNode = root;
            Node parentNode = root;
            bool isLeftChild = true;
            while (curNode.key != x)
            {
                parentNode = curNode;
                if (x < curNode.key)
                {
                    isLeftChild = true;
                    curNode = curNode.left;

                }
                else
                {
                    isLeftChild = false;
                    curNode = curNode.right;

                }
                if (curNode == null)
                    return false;
            }
            if ((curNode.left == null) && (curNode.right == null))
            {
                if (curNode == root)
                    root = null;
                else if (isLeftChild)
                    parentNode.left = null;
                else
                    parentNode.right = null;
            }
            else if (curNode.right == null)
            {
                if (curNode == root)
                    root = curNode.left;
                else if (isLeftChild)
                    parentNode.left = curNode.left;
                else
                    parentNode.right = curNode.left;
            }
            else if (curNode.left == null)
            {
                if (curNode == root)
                    root = curNode.right;
                else if (isLeftChild)
                    parentNode.left = curNode.right;
                else
                    parentNode.right = curNode.right;
            }
            else
            {
                Node subsNode = GetSubsNode(curNode);
                if (curNode == root)
                    root = subsNode;
                else if (isLeftChild)
                    parentNode.left = subsNode;
                else
                    parentNode.right = subsNode;
                subsNode.left = curNode.left;
            }

            return true;
        }
    }
}
