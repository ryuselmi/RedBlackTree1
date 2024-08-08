using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree1
{
    // Class representing a node in the Red-Black Tree
    public class Node
    {
        public int Value;
        public Color NodeColor;
        public Node Left;
        public Node Right;
        public Node Parent;

        public Node(int value)
        {
            Value = value;
            NodeColor = Color.Red;  // New nodes are always red initially
            Left = null;
            Right = null;
            Parent = null;
        }
    }
}
