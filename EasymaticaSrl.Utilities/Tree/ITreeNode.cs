using EasymaticaSrl.Utilities.Tree.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree
{
    /// <summary>
    /// It Contains methods to manipulate a tree root node.
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        ///   Add a Leaf (Node wit no children) to the node. The level of the node to add will be the will be the node level increased by one
        ///   while its wil bew the max child numver inreased by one.
        ///   
        ///   I.E.
        ///   
        /// Level1      Node1
        /// -----------------------
        /// Level2         |
        ///         -----------------
        ///         |               |
        ///      Node1             Node2
        ///      
        ///  (Level1) Node1.AddLead(NewNode) the newNode will bacamo Node3
        ///  
        /// Level1      Node1
        /// -----------------------
        /// Level2         |
        ///         -----------------
        ///         |      |        |
        ///      Node1   Node3    Node2    
        /// 
        ///   The node we want to add must have no children and no parents.
        /// </summary>
        /// <param name="treeNode"></param>
        void AddLeaf(ITreeNode treeNode);

        /// <summary>
        /// Delete a leaf from the node corresponding to a certain node number.
        /// 
        /// I.E:
        /// 
        /// Level1      Node1
        /// -----------------------
        /// Level2         |
        ///         -----------------
        ///         |       |       |
        ///      Node1    Node2   Node3
        ///--------------------------------
        /// Level3         |
        ///              Node1
        ///           
        /// (Level1) Node1.DeleteLeaf(1) --> OK Node1 will (Level2) be deleted.
        /// (Level1) Node1.DeleteLeaf(2) --> KO Node2 will (Level2) not be deleted as is not a leaf.
        /// (Level1) Node1.DeleteLeaf(3) --> OK Node1 will (Level2) be deleted.
        /// (Level2) Node2.DeleteLeaf(1) --> OK Node1 (Level3) will be deleted. 
        /// 
        /// Once deleted a node has the original state (level =1, number = 1is root, is Leaf,).
        /// 
        /// </summary>
        /// <param name="nodeNumber">The number of leaf child we want delete</param>
        void DeleteLeaf(int nodeNumber);        

        /// <summary>
        /// Return true if the three has no children and false otherwise.
        /// </summary>
        /// <returns>A boolean value</returns>
        bool IsLeaf();

        /// <summary>
        /// Return true id the tree has non parents and false otherwise.
        /// </summary>
        /// <returns>A boolean value</returns>
        bool IsRoot();

        /// <summary>
        /// Returns the level of the node.
        /// </summary>
        /// <returns>An int representing the level of the node</returns>
        int Level();

        /// <summary>
        /// Returns the node number of the node.
        /// </summary>
        /// <returns>An int representing the Node Number of the node</returns>
        int NodeNumber();

        /// <summary>
        /// Returns the number od children of the node. A value 0 will be returned if the node is a leaf.
        /// </summary>
        /// <returns>An int representing the number of the children of the node.</returns>
        int NumbOfChildren();

        /// <summary>
        /// Returns the dept of the tree having the node as root. A Leaf node had dept one. In a node whith children the dept is
        /// obtained by summing  one to the max children dept.
        /// </summary>
        /// <returns>An int representing the dept of the node.</returns>
        int Depth();

        /// <summary>
        /// Return a list of the children of the node. If the node is a leaf the lisi is empty.
        /// It is not possible to modify the list as the list is immutable. Trying to modify the resulting list
        /// an exception will be thrown.
        /// </summary>
        /// <returns>A list representing the children of the node.</returns>
        IList<ITreeNode> Children();

        /// <summary>
        /// Returns a list containing one element represeting the parent if the node has got one.
        /// Return an emty list otherwise.
        /// It is not possible to modify the list as the list is immutable. Trying to modify the resulting list
        /// an exception will be thrown.        
        /// </summary>
        /// <returns>A list representing the parent of the node.</returns>
        IList<ITreeNode> Parent();

        string Path();

        void Accept(ITreeVisitor visitor);
    }
}
