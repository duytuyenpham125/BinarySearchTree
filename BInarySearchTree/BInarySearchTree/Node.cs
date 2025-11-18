using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInarySearchTree
{
    class Node
    {
        public int key;
        public Node left;
        public Node right;

        public Node()
        {
            left = null;
            right = null;
        }
        public Node(int aKey)
        {
            left = null;
            right = null;
            key = aKey;
        }
    }
}
