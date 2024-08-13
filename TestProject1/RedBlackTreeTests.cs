using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedBlackTree1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackTree1.Tests
{
    [TestClass()]
    public class RedBlackTreeTests
    {
        [TestMethod]
        public void Insert_ShouldAddNodesCorrectly()
        {
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            Assert.IsNotNull(tree.Search(tree.GetRoot(), 10), "Node 10 should be present in the tree.");
            Assert.IsNotNull(tree.Search(tree.GetRoot(), 20), "Node 20 should be present in the tree.");
            Assert.IsNotNull(tree.Search(tree.GetRoot(), 30), "Node 30 should be present in the tree.");
        }

        [TestMethod]
        public void Search_ShouldReturnCorrectNode()
        {
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            var node = tree.Search(tree.GetRoot(), 20);
            Assert.IsNotNull(node, "Node 20 should be found in the tree.");
            Assert.AreEqual(20, node.Value, "The value of the found node should be 20.");
        }

        [TestMethod]
        public void Search_ShouldReturnNullForNonExistentNode()
        {
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            var node = tree.Search(tree.GetRoot(), 40);
            Assert.IsNull(node, "Node 40 should not be found in the tree.");
        }

        [TestMethod]
        public void Delete_ShouldRemoveNodesCorrectly()
        {
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);

            tree.Delete(20);
            Assert.IsNull(tree.Search(tree.GetRoot(), 20), "Node 20 should be removed from the tree.");
        }

        [TestMethod]
        public void Insert_Delete_ShouldMaintainTreeProperties()
        {
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(15);
            tree.Insert(25);

            tree.Delete(20);

            Assert.IsNotNull(tree.Search(tree.GetRoot(), 10), "Node 10 should be present in the tree.");
            Assert.IsNull(tree.Search(tree.GetRoot(), 20), "Node 20 should be removed from the tree.");
            Assert.IsNotNull(tree.Search(tree.GetRoot(), 30), "Node 30 should be present in the tree.");
            Assert.IsNotNull(tree.Search(tree.GetRoot(), 15), "Node 15 should be present in the tree.");
            Assert.IsNotNull(tree.Search(tree.GetRoot(), 25), "Node 25 should be present in the tree.");
        }


        [TestMethod]
        public void Insert_Delete_RootNode_ShouldMaintainTreeProperties()
        {
            RedBlackTree tree = new RedBlackTree();
            tree.Insert(10);
            tree.Delete(10);

            Assert.IsNull(tree.GetRoot(), "Root node should be null after deleting the only node in the tree.");
        }


    }
}