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
        void Attach(ITreeNode treeNodeToAttach);
        void DeleteLeaf(int index);
        void Detach();
        bool HasParent();
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
    }
}
