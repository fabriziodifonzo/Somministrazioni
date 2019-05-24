using EasymaticaSrl.Utilities.Tree.Constants;
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
            ((TreeNode)treeNode)._listParent.Add(this);
            ((TreeNode)treeNode)._level = this.Level()+1;
            ((TreeNode)treeNode)._nodeNumber = this._listChildren.Count;
        }

        public void DeleteLeaf(int nodeNumber)
        {
            CheckNodeNumberOk(nodeNumber);
            CheckNodeIfLeaf(nodeNumber);

            var child = _listChildren.ElementAt(nodeNumber - 1);
            ((TreeNode)child)._nodeNumber = 1;
            CheckIsLeaf(child);

            ((TreeNode)child)._listParent.Clear();
            ((TreeNode)child)._level = 1;
                
            _listChildren.RemoveAt(nodeNumber-1);
            RenumberChildren();
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

        public IList<ITreeNode> Children()
        {
            return _listChildren.ToImmutableList();
        }

        public IList<ITreeNode> Parent()
        {
            return _listParent.ToImmutableList();
        }

        public bool IsRoot()
        {
            return !_listParent.Any();
        }

        readonly IList<ITreeNode> _listChildren = new List<ITreeNode>();
        readonly IList<ITreeNode> _listParent = new List<ITreeNode>();
        int _level = 1;
        int _nodeNumber = 1;

        protected TreeNode()
        {
        }

        private void RenumberChildren()
        {
            int newIndex = 1;
            foreach (var treeNode in _listChildren)
            {
                ((TreeNode)treeNode)._nodeNumber = newIndex;
                newIndex++;
            }
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

        void CheckNodeNumberOk(int nodeNumber)
        {
            if (nodeNumber <= 0)
            {
                throw new TreeException(TreeConstants.ERRCODE_INVALIDNODENUMBER, TreeConstants.ERRMSG_INVALIDNODENUMBER);
            }

            if ((nodeNumber-1 < 0) || (nodeNumber-1 >= NumbOfChildren()))
            {
                throw new TreeException(TreeConstants.ERRCODE_NODENUMBERNTFOUND, TreeConstants.ERRMSG_NODENUMBERNTFOUND);
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
    }
}
