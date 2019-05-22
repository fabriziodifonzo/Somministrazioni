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
            CheckIsLeaf(treeNode);

            treeNode.AddParent(this);
            _listChildren.Add(treeNode);
            treeNode.SetLevel(this.Level() + 1);
            treeNode.SetIndex(this._listChildren.Count);

            if (_isLeaf)
            {
                _isLeaf = false;
            }
        }

        public void AddParent(ITreeNode treeNode)
        {
            CheckAddParentParameters(treeNode);
            CheckNodeHasNoParent(treeNode);

            _listParent.Add(treeNode);
        }

        public void DeleteLeaf(int index)
        {
            CheckIndexOk(index);
            CheckNodeIfLeaf(index);

            var child = _listChildren.ElementAt(index - 1);
            child.Detach();
            child.SetLevel(1);
            _listChildren.RemoveAt(index - 1);
           
            int newIndex = 1;
            foreach(var treeNode in _listChildren)
            {
                treeNode.SetIndex(newIndex++);
            }

            _isLeaf |= !_listChildren.Any();
        }

        public void Detach()
        {
            _listParent.Clear();
        }

        public bool HasParent()
        {
            return _listParent.Any();
        }

        public bool IsLeaf()
        {
            return _isLeaf;
        }

        public int Level()
        {
           return _level;
        }

        public int Index()
        {
            return _index;
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
                    dept  = Math.Max(dept, treeNode.Depth());
                }
                return dept + 1;
            }

        }

        public void SetLevel(int level)
        {
            _level = level;
        }

        public void SetIndex(int index)
        {
            _index = index;
        }

        public IList<ITreeNode> Children()
        {
            return _listChildren.ToImmutableList();
        }

        public IList<ITreeNode> Parent()
        {
            return _listParent.ToImmutableList();
        }

        readonly IList<ITreeNode> _listChildren = new List<ITreeNode>();
        readonly IList<ITreeNode> _listParent = new List<ITreeNode>();
        int _level = 1;
        int _index = 1;
        bool _isLeaf = true;

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
            Contract.Contract.Precondiction(treeNode != null, Constants.Constants.ERRMSG_TREANODECANNOTBENULL);

            if (!treeNode.IsLeaf())
            {
                throw new TreeException(Constants.Constants.ERRCODE_LEAFNODENEEDED, Constants.Constants.ERRMSG_LEAFNODENEEDED);
            }
        }

        void CheckAddParentParameters(ITreeNode treeNode)
        {
            if (treeNode == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(treeNode));
            }
        }

        void CheckNodeHasNoParent(ITreeNode treeNode)
        {
            Contract.Contract.Precondiction(treeNode != null, Constants.Constants.ERRMSG_TREANODECANNOTBENULL);

            if (treeNode.HasParent())
            {
                throw new TreeException(Constants.Constants.ERRCODE_TREEALREADYHASAPARENT, Constants.Constants.ERRMSG_TREEALREADYHASAPARENT);
            }
        }

        void CheckIndexOk(int index)
        {
            if ((index < 0) || (index > NumbOfChildren()))
            {
                throw new TreeException(Constants.Constants.ERRCODE_WROONGINDEX, Constants.Constants.ERRMSG_WROONGINDEX);
            }
        }

        void CheckNodeIfLeaf(int index)
        {
            if (!_listChildren.ElementAt(index - 1).IsLeaf())
            {
                throw new TreeException(Constants.Constants.ERRCODE_LEAFNODENEEDED, Constants.Constants.ERRMSG_LEAFNODENEEDED);
            }
        }
    }
}
