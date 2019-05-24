using EasymaticaSrl.Utilities.Tree.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree
{
    public interface ITreeNode
    {
        void AddLeaf(ITreeNode treeNode);        
        void DeleteLeaf(int index);        
        bool IsLeaf();        
        int Level();
        int NodeNumber();
        int NumbOfChildren();
        int Depth();
        void SetLevel(int level);
        void SetNodeNumber(int index);
        IList<ITreeNode> Children();
        IList<ITreeNode> Parent();
        NodeStatus NodeStatus();
        bool IsRoot();
    }
}
