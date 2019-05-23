using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree.Enums
{
    public enum NodeStatus
    {
        //When the node is just created
        ROOT = 0,     

        //When the node is inserted in the child list
        INSERTED = 1,

        //When the node is inserted in the child list and attached to the parent
        ATTACHED = 2
    }
}
