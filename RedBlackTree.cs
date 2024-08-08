using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree1
{
    public class RedBlackTree
    {
        private Node root;  // Root node of the tree

        public RedBlackTree()
        {
            root = null; // Initialize the tree with an empty root
        }

        // Method to insert a new value into the tree
        public void Insert(int value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
                root.NodeColor = Color.Black;  // Root node is always black
            }
            else
            {
                Node parent = null;
                Node current = root;
                // Find the appropriate parent for the new node
                while (current != null)
                {
                    parent = current;
                    if (value < current.Value)
                        current = current.Left;
                    else
                        current = current.Right;
                }

                newNode.Parent = parent;
                if (value < parent.Value)
                    parent.Left = newNode;
                else
                    parent.Right = newNode;

                FixInsert(newNode);  // Fix any Red-Black Tree violations
            }
        }

        // Method to fix the Red-Black Tree properties after insertion
        private void FixInsert(Node node)
        {
            while (node != root && node.Parent.NodeColor == Color.Red)
            {
                if (node.Parent == node.Parent.Parent.Left)
                {
                    Node uncle = node.Parent.Parent.Right;
                    if (uncle != null && uncle.NodeColor == Color.Red)
                    {
                        // Case 1: Uncle is red
                        node.Parent.NodeColor = Color.Black;
                        uncle.NodeColor = Color.Black;
                        node.Parent.Parent.NodeColor = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            // Case 2: Node is a right child
                            node = node.Parent;
                            LeftRotate(node);
                        }
                        // Case 3: Node is a left child
                        node.Parent.NodeColor = Color.Black;
                        node.Parent.Parent.NodeColor = Color.Red;
                        RightRotate(node.Parent.Parent);
                    }
                }
                else
                {
                    Node uncle = node.Parent.Parent.Left;
                    if (uncle != null && uncle.NodeColor == Color.Red)
                    {
                        // Case 1: Uncle is red
                        node.Parent.NodeColor = Color.Black;
                        uncle.NodeColor = Color.Black;
                        node.Parent.Parent.NodeColor = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            // Case 2: Node is a left child
                            node = node.Parent;
                            RightRotate(node);
                        }
                        // Case 3: Node is a right child
                        node.Parent.NodeColor = Color.Black;
                        node.Parent.Parent.NodeColor = Color.Red;
                        LeftRotate(node.Parent.Parent);
                    }
                }
            }
            root.NodeColor = Color.Black;  // Ensure the root is black
        }

        // Left rotation method
        private void LeftRotate(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            if (temp.Left != null)
                temp.Left.Parent = node;

            temp.Parent = node.Parent;
            if (node.Parent == null)
                root = temp;
            else if (node == node.Parent.Left)
                node.Parent.Left = temp;
            else
                node.Parent.Right = temp;

            temp.Left = node;
            node.Parent = temp;
        }

        // Right rotation method
        private void RightRotate(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            if (temp.Right != null)
                temp.Right.Parent = node;

            temp.Parent = node.Parent;
            if (node.Parent == null)
                root = temp;
            else if (node == node.Parent.Right)
                node.Parent.Right = temp;
            else
                node.Parent.Left = temp;

            temp.Right = node;
            node.Parent = temp;
        }

        // Method to delete a node from the tree
        public void Delete(int value)
        {
            Node nodeToDelete = Search(root, value);
            if (nodeToDelete == null)
                return;

            Node y = nodeToDelete;
            Color originalColor = y.NodeColor;
            Node x;

            if (nodeToDelete.Left == null)
            {
                x = nodeToDelete.Right;
                Transplant(nodeToDelete, nodeToDelete.Right);
            }
            else if (nodeToDelete.Right == null)
            {
                x = nodeToDelete.Left;
                Transplant(nodeToDelete, nodeToDelete.Left);
            }
            else
            {
                y = Minimum(nodeToDelete.Right);
                originalColor = y.NodeColor;
                x = y.Right;
                if (y.Parent == nodeToDelete)
                {
                    if (x != null)
                        x.Parent = y;
                }
                else
                {
                    Transplant(y, y.Right);
                    y.Right = nodeToDelete.Right;
                    y.Right.Parent = y;
                }

                Transplant(nodeToDelete, y);
                y.Left = nodeToDelete.Left;
                y.Left.Parent = y;
                y.NodeColor = nodeToDelete.NodeColor;
            }

            if (originalColor == Color.Black)
                FixDelete(x);
        }

        // Method to replace one subtree with another
        private void Transplant(Node target, Node with)
        {
            if (target.Parent == null)
                root = with;
            else if (target == target.Parent.Left)
                target.Parent.Left = with;
            else
                target.Parent.Right = with;

            if (with != null)
                with.Parent = target.Parent;
        }

        // Method to fix the Red-Black Tree properties after deletion
        private void FixDelete(Node node)
        {
            while (node != root && GetColor(node) == Color.Black)
            {
                if (node == node.Parent.Left)
                {
                    Node sibling = node.Parent.Right;
                    if (GetColor(sibling) == Color.Red)
                    {
                        sibling.NodeColor = Color.Black;
                        node.Parent.NodeColor = Color.Red;
                        LeftRotate(node.Parent);
                        sibling = node.Parent.Right;
                    }

                    if (GetColor(sibling.Left) == Color.Black && GetColor(sibling.Right) == Color.Black)
                    {
                        sibling.NodeColor = Color.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        if (GetColor(sibling.Right) == Color.Black)
                        {
                            sibling.Left.NodeColor = Color.Black;
                            sibling.NodeColor = Color.Red;
                            RightRotate(sibling);
                            sibling = node.Parent.Right;
                        }

                        sibling.NodeColor = node.Parent.NodeColor;
                        node.Parent.NodeColor = Color.Black;
                        sibling.Right.NodeColor = Color.Black;
                        LeftRotate(node.Parent);
                        node = root;
                    }
                }
                else
                {
                    Node sibling = node.Parent.Left;
                    if (GetColor(sibling) == Color.Red)
                    {
                        sibling.NodeColor = Color.Black;
                        node.Parent.NodeColor = Color.Red;
                        RightRotate(node.Parent);
                        sibling = node.Parent.Left;
                    }

                    if (GetColor(sibling.Right) == Color.Black && GetColor(sibling.Left) == Color.Black)
                    {
                        sibling.NodeColor = Color.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        if (GetColor(sibling.Left) == Color.Black)
                        {
                            sibling.Right.NodeColor = Color.Black;
                            sibling.NodeColor = Color.Red;
                            LeftRotate(sibling);
                            sibling = node.Parent.Left;
                        }

                        sibling.NodeColor = node.Parent.NodeColor;
                        node.Parent.NodeColor = Color.Black;
                        sibling.Left.NodeColor = Color.Black;
                        RightRotate(node.Parent);
                        node = root;
                    }
                }
            }
            if (node != null)
                node.NodeColor = Color.Black;
        }

        // Method to get the color of a node
        private Color GetColor(Node node)
        {
            if (node == null)
                return Color.Black;
            return node.NodeColor;
        }

        // Method to search for a node with a specific value
        public Node Search(Node node, int value)
        {
            while (node != null && value != node.Value)
            {
                if (value < node.Value)
                    node = node.Left;
                else
                    node = node.Right;
            }
            return node;
        }

        // Method to find the minimum value node in a subtree
        private Node Minimum(Node node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        // Method for in-order traversal of the tree
        public void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.WriteLine($"{node.Value} ({node.NodeColor})");
                InOrderTraversal(node.Right);
            }
        }

        // Method to get the root of the tree
        public Node GetRoot()
        {
            return root;
        }
    }
}
