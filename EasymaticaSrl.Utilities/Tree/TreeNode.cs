using EasymaticaSrl.Utilities.Tree.Constants;
using EasymaticaSrl.Utilities.Tree.Enums;
using EasymaticaSrl.Utilities.Tree.Exceptions;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree
{
    public class TreeNode : ITreeNode
    {
        public static ITreeNode Create()
        {
            return new TreeNode();
        }

        public void AddLeaf(ITreeNode treeNode)
        {
            CheckAddChildParameters(treeNode);
            CheckIsRootAndLeaf(treeNode);

            _listChildren.Add(treeNode);
            ((TreeNode)treeNode).ChangeStatus(Enums.NodeStatus.INSERTED);
            ((TreeNode)treeNode).Attach(this);
            ((TreeNode)treeNode).ChangeStatus(Enums.NodeStatus.ATTACHED);
            treeNode.SetLevel(this.Level() + 1);
            treeNode.SetNodeNumber(this._listChildren.Count);
        }

        public void DeleteLeaf(int index)
        {
            CheckIndexOk(index);
            CheckNodeIfLeaf(index);
            var child = _listChildren.ElementAt(index - 1);
            child.SetNodeNumber(1);
            CheckIsLeaf(child);

            ((TreeNode)child).Detach();
            child.SetLevel(1);
            _listChildren.RemoveAt(index - 1);
            ((TreeNode)child).ChangeStatus(Enums.NodeStatus.ROOT);

            int newIndex = 1;
            foreach (var treeNode in _listChildren)
            {
                treeNode.SetNodeNumber(newIndex);
                newIndex++;
            }
        }

        public bool IsLeaf()
        {
            return !_listChildren.Any();
        }

        public int Level()
        {
            return _level;
        }

        public int NodeNumber()
        {
            return _nodeNumber;
        }

        public int NumbOfChildren()
        {
            return _listChildren.Count();
        }

        public int Depth()
        {
            if (IsLeaf())
            {
                return 1;
            }
            else {

                var dept = 0;
                foreach (var treeNode in Children())
                {
                    dept = Math.Max(dept, treeNode.Depth());
                }
                return dept + 1;
            }

        }

        public void SetLevel(int level)
        {
            _level = level;
        }

        public void SetNodeNumber(int index)
        {
            _nodeNumber = index;
        }

        public IList<ITreeNode> Children()
        {
            return _listChildren.ToImmutableList();
        }

        public IList<ITreeNode> Parent()
        {
            return _listParent.ToImmutableList();
        }

        public NodeStatus NodeStatus()
        {
            return _nodeStatus; 
        }

        public bool IsRoot()
        {
            return !_listParent.Any();
        }

        void ChangeStatus(Enums.NodeStatus nodeStatus)
        {
            _nodeStatus = nodeStatus;
        }

        void Attach(ITreeNode treeNodeToAttach)
        {
            CheckAttachParameters(treeNodeToAttach);
            CheckNodeStatusInserted(this);
            CheckAttachToNodeAbove(treeNodeToAttach);

            _listParent.Add(treeNodeToAttach);
        }

        void Detach()
        {
            CheckNodeStatusAttached();
            _nodeStatus = Enums.NodeStatus.INSERTED;

            _listParent.Clear();
        }

        readonly IList<ITreeNode> _listChildren = new List<ITreeNode>();
        readonly IList<ITreeNode> _listParent = new List<ITreeNode>();
        int _level = 1;
        int _nodeNumber = 1;
        NodeStatus _nodeStatus = Enums.NodeStatus.ROOT;

        protected TreeNode()
        {
        }

        void CheckAddChildParameters(ITreeNode treeNode)
        {
            if (treeNode == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(treeNode));
            }
        }

        void CheckIsLeaf(ITreeNode treeNode)
        {
            Contract.Contract.Precondiction(treeNode != null, Constants.TreeConstants.ERRMSG_TREANODECANNOTBENULL);

            if (!treeNode.IsLeaf())
            {
                throw new TreeException(Constants.TreeConstants.ERRCODE_LEAFNODENEEDED, Constants.TreeConstants.ERRMSG_LEAFNODENEEDED);
            }
        }

        void CheckAttachParameters(ITreeNode treeNode)
        {
            if (treeNode == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(treeNode));
            }
        }

        void CheckAttachToNodeAbove(ITreeNode treeNodeToAttach)
        {
            Contract.Contract.Precondiction(treeNodeToAttach != null, Constants.TreeConstants.ERRMSG_TREANODECANNOTBENULL);

            if (_listChildren.Contains(treeNodeToAttach))
            {
                throw new TreeException(TreeConstants.ERRCODE_ONELEVELABOVEISNEEDEDFORATTACH, TreeConstants.ERRMSG_ONELEVELABOVEISNEEDEDFORATTACH);
            }  
        }

        void CheckNodeStatusInserted(ITreeNode treeNodeToAttach)
        {
            Contract.Contract.Precondiction(treeNodeToAttach != null, Constants.TreeConstants.ERRMSG_TREANODECANNOTBENULL);

            if (treeNodeToAttach.NodeStatus() != Enums.NodeStatus.INSERTED)
            {
                throw new TreeException(TreeConstants.ERRCODE_INSERTEDNODENEEDED, TreeConstants.ERRMSG_INSERTEDNODENEEDED);
            }
        }

        void CheckNodeStatusAttached()
        {
            if (NodeStatus() != Enums.NodeStatus.ATTACHED)
            {
                throw new TreeException(TreeConstants.ERRCODE_ATTACHEDNODENEEDED, TreeConstants.ERRMSG_ATTACHEDNODENEEDED);
            }
        }


        void CheckIndexOk(int index)
        {
            if ((index -1 < 0) || (index - 1 >= NumbOfChildren()))
            {
                throw new TreeException(Constants.TreeConstants.ERRCODE_WROONGINDEX, Constants.TreeConstants.ERRMSG_WROONGINDEX);
            }
        }

        void CheckNodeIfLeaf(int index)
        {
            if (!_listChildren.ElementAt(index-1).IsLeaf())
            {
                throw new TreeException(Constants.TreeConstants.ERRCODE_LEAFNODENEEDED, Constants.TreeConstants.ERRMSG_LEAFNODENEEDED);
            }
        }

        void CheckIsRootAndLeaf(ITreeNode treeNode)
        {       
            if (!(treeNode.IsLeaf() && treeNode.IsRoot()))
            {
                throw new TreeException(Constants.TreeConstants.ERRCODE_LEAFANDROOTNODENEEDED, Constants.TreeConstants.ERRMSG_LEAFANDROOTNODENEEDED);
            }
        }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;
            return node != null &&
                   _level == node._level &&
                   _nodeNumber == node._nodeNumber;
        }

        public override int GetHashCode()
        {
            var hashCode = -1096092623;
            hashCode = hashCode * -1521134295 + _level.GetHashCode();
            hashCode = hashCode * -1521134295 + _nodeNumber.GetHashCode();
            return hashCode;
        }
    }
}
