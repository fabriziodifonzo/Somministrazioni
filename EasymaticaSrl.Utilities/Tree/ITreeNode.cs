using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree
{
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
        /// </summary>
        /// <param name="nodeNumber">The number of leaf child we want delete</param>
        void DeleteLeaf(int nodeNumber);        


        bool IsLeaf();        
        int Level();
        int NodeNumber();
        int NumbOfChildren();
        int Depth();
        void SetLevel(int level);
        void SetNodeNumber(int index);
        IList<ITreeNode> Children();
        IList<ITreeNode> Parent();
        bool IsRoot();
    }
}
