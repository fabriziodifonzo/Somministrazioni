using EasymaticaSrl.Utilities.Tree;
using EasymaticaSrl.Utilities.Tree.Constants;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Test.Test
{
    [TestFixture]
    public class TreeTest
    {

        /*
        void AddLeaf(ITreeNode treeNode);        
        void AddParent(ITreeNode treeNode);
        void DeleteLeaf(int index);
        bool HasParent();
        bool IsLeaf();        
        int Level();
        int Index();
        int NumbOfChildren();
        int Depth();
        void SetLevel(int level);
        void SetIndex(int index);
        IList<ITreeNode> Childreen();
        IList<ITreeNode> Parent();
         * /

        /**
         * This test just creates a node;
         */
        [Test]
        public void VerifyLeafWithNoParent()
        {
            var leaf = TreeNode.Create();

            Assert.IsTrue(leaf.IsLeaf(), Constants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(leaf.HasParent());
            Assert.IsFalse(leaf.Parent().Any());
            Assert.IsFalse(leaf.Children().Any());
            Assert.AreEqual(1, leaf.Level());
            Assert.AreEqual(1, leaf.Index());
            Assert.AreEqual(0, leaf.NumbOfChildren());
            Assert.AreEqual(1, leaf.Depth());
        }

        /**
         * This test create to node and the add a node to another;
         */
        [Test]
        public void VerifyNodWithAChlidLeaf()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), Constants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node1.HasParent());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.Index());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), Constants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node2.HasParent());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.Index());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            node1.AddLeaf(node2);

            Assert.IsFalse(node1.IsLeaf(), Constants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node1.HasParent());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.Index());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsTrue(node2.HasParent());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.Index());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());
        }

        /**
         * This test add anote to another and then delete the last one.
        */
        [Test]
        public void VerifyDeleteNode()
        { 
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), Constants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node1.HasParent());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.Index());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), Constants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node2.HasParent());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.Index());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            node1.AddLeaf(node2);

            Assert.IsFalse(node1.IsLeaf(), Constants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node1.HasParent());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.Index());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsTrue(node2.HasParent());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.Index());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            node1.DeleteLeaf(node2.Index());

            Assert.IsTrue(node1.IsLeaf(), Constants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node1.HasParent());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.Index());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            Assert.IsTrue(node2.IsLeaf(), Constants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node2.HasParent());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.Index());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());
        }
    }
}
