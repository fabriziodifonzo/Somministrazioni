﻿using EasymaticaSrl.Utilities.Tree;
using EasymaticaSrl.Utilities.Tree.Constants;
using EasymaticaSrl.Utilities.Tree.Exceptions;
using EasymaticaSrl.Utilities.Tree.Visitors;
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
        /**
         * This test just creates a node;
         * 
         * Node1
         */
        [Test]
        public void VerifyLeafWithNoParent()
        {
            var leaf = TreeNode.Create();

            Assert.IsTrue(leaf.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(leaf.IsRoot());
            Assert.IsFalse(leaf.Parent().Any());
            Assert.IsFalse(leaf.Children().Any());
            Assert.AreEqual(1, leaf.Level());
            Assert.AreEqual(1, leaf.NodeNumber());
            Assert.AreEqual(0, leaf.NumbOfChildren());
            Assert.AreEqual(1, leaf.Depth());
        }

        /**
         * This test creates two nodes 
         * 
         *      Node1     Node2
         * 
         * and then add a node to another
         * 
         *      Node1
         *        |  
         *      Node2
         */
        [Test]
        public void VerifyAddNode1()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            node1.AddLeaf(node2);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());
        }


        /**
         * This test creates three nodes 
         * 
         *      Node1     Node2  Node3
         * 
         * and then add a node to another in multiple level
         * 
         *      Node1
         *        |  
         *      Node2
         *        |
         *      Node3 
         */
        [Test]
        public void VerifyAddNode2()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            var node3 = TreeNode.Create();

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            /*
             *  Node1 (Level1)
             *    |
             *  Node2 (Level2)
             *  
             */
            node1.AddLeaf(node2);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            /*
             *  Node1 (Level1)
             *    |
             *  Node2 (Level2)
             *     |
             *  Node3 (Level3)
             */
            node2.AddLeaf(node3);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(3, node1.Depth());

            Assert.IsFalse(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsTrue(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(1, node2.NumbOfChildren());
            Assert.AreEqual(2, node2.Depth());

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(3, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());
        }

        /**
         * This test creates two nodes 
         * 
         *      Node1     Node2
         * 
         * then add a node to another
         * 
         *      Node1
         *        |  
         *      Node2
         *      
         *  Next create another nodes
         *  
         *      Node3
         *      
         *  And then try to add the Node1 to Node 2:
         *  
         *      Node3
         *        |  
         *      Node1
         *        |
         *      Node2
         *      
         *    An exception will be thrown as we are only able to add a leaf node!
         *    
         */
        [Test]
        public void VerifyAddNode3()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            node1.AddLeaf(node2);

            var node3 = TreeNode.Create();

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            bool leafAndNodeNeededExceptionThrown = false;
            try
            {
                node3.AddLeaf(node1);
            }
            catch (TreeException e)
            {
                leafAndNodeNeededExceptionThrown |= e.ErrorCode == TreeConstants.ERRCODE_LEAFANDROOTNODENEEDED;
            }

            Assert.IsTrue(leafAndNodeNeededExceptionThrown);

            node1.DeleteLeaf(node2.NodeNumber());

            //Now node1 is a leaf and I can add it!
            node3.AddLeaf(node1);

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node1.IsRoot());
            Assert.IsTrue(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(2, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            Assert.IsFalse(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsTrue(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(1, node3.NumbOfChildren());
            Assert.AreEqual(2, node3.Depth());
        }

        /**
         * This test add a node to another and then delete the last one.
         */
        [Test]
        public void VerifyDeleteNode1()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            node1.AddLeaf(node2);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            node1.DeleteLeaf(node2.NodeNumber());

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());
        }

        /**
         * This test try to Add a node that has not a parent.
         */
        [Test]
        public void VerifyAddNodeNotLeaf()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            node1.AddLeaf(node2);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            var node3 = TreeNode.Create();
            node1.DeleteLeaf(node2.NodeNumber());
            node3.AddLeaf(node2);
        }

        /**
         * This test add a two nodes to another 
         * 
         *                  Node1
         *                    |
         *                 -------------    
         *                 |           |
         *               Node2      Node3
         *               
         * and then delete the first one:
         * 
         *               Node1
         *                 |
         *               Node3         
        */
        [Test]
        public void VerifyDeleteNode2()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            var node3 = TreeNode.Create();

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            /*
             *      Node1     (Level1)
             *        |
             *      ----------  
             *      |         |
             *    Node2     Node3     (Level2)
            */
            node1.AddLeaf(node2);
            node1.AddLeaf(node3);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(2, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf());
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(2, node3.Level());
            Assert.AreEqual(2, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            /*
             *      Node1     (Level1)
             *        |
             *      Node3     (Level2)
            */
            node1.DeleteLeaf(node2.NodeNumber());

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(2, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());
        }

        /**
         * This test add a two nodes to another:
         * 
         *                  Node1
         *                    |
         *                 -------------    
         *                 |           |
         *               Node2      Node3
         *               
         *  and then delete the last one:
         *  
         *                  Node1
         *                    |         
         *                  Node2      
        */
        [Test]
        public void VerifyDeleteNode3()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            var node3 = TreeNode.Create();

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());


            /*
             *      Node1     (Level1)
             *        |
             *      ----------  
             *      |         |
             *    Node2     Node3     (Level2)
            */
            node1.AddLeaf(node2);
            node1.AddLeaf(node3);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(2, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf());
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(2, node3.Level());
            Assert.AreEqual(2, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            /*
             *      Node1     (Level1)
             *        |
             *      Node2     (Level2)
            */
            node1.DeleteLeaf(node3.NodeNumber());

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());
        }

        /**
         * This test add a two nodes to another 
         * 
         *                  Node1
         *                    |
         *                 -------------    
         *                 |           |
         *               Node2      Node3
         *               
         *  then delete the last one.              
         *               
         *                  Node1
         *                    |
         *                  Node2 
         *                  
         *  then reaadd to Node1 again                
        */
        [Test]
        public void VerifyDeleteNode4()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            var node3 = TreeNode.Create();

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());


            /*
             *      Node1     (Level1)
             *        |
             *      ----------  
             *      |         |
             *    Node2     Node3     (Level2)
            */
            node1.AddLeaf(node2);
            node1.AddLeaf(node3);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(2, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf());
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(2, node3.Level());
            Assert.AreEqual(2, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            /*
             *      Node1     (Level1)
             *        |
             *      Node2     (Level2)
            */
            node1.DeleteLeaf(node3.NodeNumber());

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            node1.AddLeaf(node3);

            /*
             *      Node1     (Level1)
             *        |
             *      ----------  
             *      |         |
             *    Node2     Node3     (Level2)
            */
            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(2, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf());
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(2, node3.Level());
            Assert.AreEqual(2, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

        }

        /**
         * This test add a two nodes to another 
         * 
         *                  Node1
         *                    |
         *                 -------------    
         *                 |           |
         *               Node2      Node3
         *               
         * then delete the first one:
         * 
         *               Node1
         *                 |
         *               Node3   
         *               
         * and readd the Node2:
         * 
         *                  Node1
         *                    |
         *                 -------------    
         *                 |           |
         *               Node3      Node2
         *               
         *  Note that Node2 in in last position now;             
         * 
        */
        [Test]
        public void VerifyDeleteNode6()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            var node3 = TreeNode.Create();

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            /*
             *      Node1     (Level1)
             *        |
             *      ----------  
             *      |         |
             *    Node2     Node3     (Level2)
            */
            node1.AddLeaf(node2);
            node1.AddLeaf(node3);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(2, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf());
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(2, node3.Level());
            Assert.AreEqual(2, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            /*
             *      Node1     (Level1)
             *        |
             *      Node3     (Level2)
            */
            node1.DeleteLeaf(node2.NodeNumber());

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(2, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());


            /*
             *      Node1     (Level1)
             *        |
             *       ------------
             *       |          |
             *      Node3     Node2  (Level2)
            */
            node1.AddLeaf(node2);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(2, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(2, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(2, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());
        }

        /**
         * This test method perform several delete test.
         */
        [Test]
        public void VerifyDeleteNode7()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            //---- Trying to delete the the node number one but tree has no node.

            bool wrongIndexExceptionThrown = false;
            try
            {
                node1.DeleteLeaf(1);
            }
            catch (TreeException e)
            {
                wrongIndexExceptionThrown |= e.ErrorCode == TreeConstants.ERRCODE_NODENUMBERNTFOUND;
            }

            Assert.IsTrue(wrongIndexExceptionThrown);

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            //Now the deletion is possible.
            node1.AddLeaf(node2);
            node1.DeleteLeaf(1);

            //--- Trying to delete node with invalid node number (Node number will start to 0) ------

            node1.AddLeaf(node2);

            wrongIndexExceptionThrown = false;
            try
            {
                node1.DeleteLeaf(0);
            }
            catch (TreeException e)
            {
                wrongIndexExceptionThrown |= e.ErrorCode == TreeConstants.ERRCODE_INVALIDNODENUMBER;
            }

            Assert.IsTrue(wrongIndexExceptionThrown);

            //---- Trying to delete the the node number two but tree only has one node.

            wrongIndexExceptionThrown = false;
            try
            {
                node1.DeleteLeaf(2);
            }
            catch (TreeException e)
            {
                wrongIndexExceptionThrown |= e.ErrorCode == TreeConstants.ERRCODE_NODENUMBERNTFOUND;
            }

            Assert.IsTrue(wrongIndexExceptionThrown);

            //Ok
            node1.DeleteLeaf(1);
        }

        /**
         * This test first create a tree like this:
         * 
         *  Node1
         *    |
         *  Node2  
         *    |
         *  Node3 
         *  
         *  And the try del delete Node 2
         * 
         */
        [Test]
        public void VerifyDeleteNode8()
        {
            var node1 = TreeNode.Create();

            Assert.IsTrue(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsFalse(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(0, node1.NumbOfChildren());
            Assert.AreEqual(1, node1.Depth());

            var node2 = TreeNode.Create();

            Assert.IsTrue(node2.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node2.IsRoot());
            Assert.IsFalse(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(1, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            var node3 = TreeNode.Create();

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node3.IsRoot());
            Assert.IsFalse(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(1, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            /*
             *  Node1 (Level1)
             *    |
             *  Node2 (Level2)
             *  
             */
            node1.AddLeaf(node2);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(2, node1.Depth());

            Assert.IsTrue(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsFalse(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(0, node2.NumbOfChildren());
            Assert.AreEqual(1, node2.Depth());

            /*
             *  Node1 (Level1)
             *    |
             *  Node2 (Level2)
             *     |
             *  Node3 (Level3)
             */
            node2.AddLeaf(node3);

            Assert.IsFalse(node1.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsTrue(node1.IsRoot());
            Assert.IsFalse(node1.Parent().Any());
            Assert.IsTrue(node1.Children().Any());
            Assert.AreEqual(1, node1.Level());
            Assert.AreEqual(1, node1.NodeNumber());
            Assert.AreEqual(1, node1.NumbOfChildren());
            Assert.AreEqual(3, node1.Depth());

            Assert.IsFalse(node2.IsLeaf());
            Assert.IsFalse(node2.IsRoot());
            Assert.IsTrue(node2.Parent().Any());
            Assert.IsTrue(node2.Children().Any());
            Assert.AreEqual(2, node2.Level());
            Assert.AreEqual(1, node2.NodeNumber());
            Assert.AreEqual(1, node2.NumbOfChildren());
            Assert.AreEqual(2, node2.Depth());

            Assert.IsTrue(node3.IsLeaf(), TreeConstants.ERRMSG_LEAFNODENEEDED);
            Assert.IsFalse(node3.IsRoot());
            Assert.IsTrue(node3.Parent().Any());
            Assert.IsFalse(node3.Children().Any());
            Assert.AreEqual(3, node3.Level());
            Assert.AreEqual(1, node3.NodeNumber());
            Assert.AreEqual(0, node3.NumbOfChildren());
            Assert.AreEqual(1, node3.Depth());

            bool leafNodeNeedExceptionThrown = false;
            try
            {
                node1.DeleteLeaf(1);
            }
            catch (TreeException e)
            {
                leafNodeNeedExceptionThrown |= e.ErrorCode == TreeConstants.ERRCODE_LEAFNODENEEDED;
            }

            Assert.IsTrue(leafNodeNeedExceptionThrown);

            //Ok now
            node2.DeleteLeaf(1);            
            node1.DeleteLeaf(1);
        }

        [Test]
        public void VerifyPreOrderTrasverse()
        {
            var node1 = TreeNode.Create();
            var node_1_1 = TreeNode.Create();
            var node_2_1 = TreeNode.Create();
            var node_3_1 = TreeNode.Create();

            var node_1_1_1 = TreeNode.Create();
            var node_2_2_2 = TreeNode.Create();
            var node_3_3_1 = TreeNode.Create();


            node1.AddLeaf(node_1_1);
            node1.AddLeaf(node_2_1);
            node1.AddLeaf(node_3_1);

            node_1_1.AddLeaf(node_1_1_1);
            node_2_1.AddLeaf(node_2_2_2);
            node_3_1.AddLeaf(node_3_3_1);

            node1.Accept(new PreOrderVisitor());
        }
    }
}
