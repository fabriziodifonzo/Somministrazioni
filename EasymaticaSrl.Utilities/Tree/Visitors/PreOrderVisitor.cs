using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree.Visitors
{
    public class PreOrderVisitor : ITreeVisitor
    {
        public IDictionary<int, IList<ITreeNode>> Visit(ITreeNode treeRootNode, IDictionary<int, IList<ITreeNode>> mapTree)    
        {            
            IList<ITreeNode> listNodes = null;
            if (mapTree.TryGetValue(treeRootNode.Level(), out listNodes))
            {
                listNodes.Add(treeRootNode);
            }
            else {
                listNodes = new List<ITreeNode>();
                listNodes.Add(treeRootNode);
                mapTree.Add(treeRootNode.Level(), listNodes);
            }

            foreach (var treeNode in treeRootNode.Children())
            {
                mapTree = Visit(treeNode, mapTree);
            }

            return mapTree;
        }

        IDictionary<int, IList<ITreeNode>> MakeTree(ITreeNode treeNode, int level, IDictionary<int, IList<ITreeNode>> tree)
        {
            Contract.Contract.Precondiction(treeNode != null, GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(treeNode));

            IDictionary<int, IList<ITreeNode>> treeToReturn = tree;

            IList <ITreeNode> listNodes = new List<ITreeNode>();
            if (treeNode.IsRoot())
            {
                listNodes.Add(treeNode);
                tree.Add(level, listNodes);
                if (!treeNode.IsLeaf())
                {
                    treeToReturn = MakeTree(treeNode.Children().First(), ++level, tree);
                }
                return treeToReturn;
            }
            else if (!treeNode.IsLeaf())
            {
                foreach (var parent in treeNode.Parent())
                {
                    listNodes.Add(treeNode);
                }
                treeToReturn.Add(level, listNodes);
                return MakeTree(treeNode.Children().First(), ++level, treeToReturn);
            }
            else //Leaf
            {
                foreach (var parent in treeNode.Parent().First().Children())
                {
                    listNodes.Add(treeNode);
                }
                treeToReturn.Add(level, listNodes);
                return treeToReturn;
            }              
        }

        readonly int ROOT_LEVEL = 1;
    }
}
