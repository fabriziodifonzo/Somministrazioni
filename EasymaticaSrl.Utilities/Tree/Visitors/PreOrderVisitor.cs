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
            CheckVisitParameters(treeRootNode, mapTree);

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

        void CheckVisitParameters(ITreeNode treeRootNode, IDictionary<int, IList<ITreeNode>> mapTree)
        {
            if (treeRootNode == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(treeRootNode));
            }
            if (mapTree == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(mapTree));
            }
        }

        readonly int ROOT_LEVEL = 1;
    }
}
