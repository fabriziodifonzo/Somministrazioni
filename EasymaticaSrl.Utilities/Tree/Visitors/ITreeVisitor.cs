using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree.Visitors
{
    public interface ITreeVisitor
    {
        IDictionary<int, IList<ITreeNode>> Visit(ITreeNode treeRootNode, IDictionary<int, IList<ITreeNode>> mapTree);
    }
}
