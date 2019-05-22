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
        void AddParent(ITreeNode treeNode);
        void DeleteLeaf(int index);
        void Detach();
        bool HasParent();
        bool IsLeaf();        
        int Level();
        int Index();
        int NumbOfChildren();
        int Depth();
        void SetLevel(int level);
        void SetIndex(int index);
        IList<ITreeNode> Children();
        IList<ITreeNode> Parent();
    }
}
