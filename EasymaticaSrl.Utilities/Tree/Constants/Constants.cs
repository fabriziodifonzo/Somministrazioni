using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree.Constants
{
    public static class Constants
    {
        //---- Error codes ---

        public const int ERRCODE_TREEALREADYHASAPARENT = 0;
        public const int ERRCODE_LEAFNODENEEDED = 1;
        public const int ERRCODE_TREANODECANNOTBENULL = 2;
        public const int ERRCODE_WROONGINDEX = 3;

        //---- Error messages ---

        public const string ERRMSG_TREEALREADYHASAPARENT = "The tree already has a parent";
        public const string ERRMSG_LEAFNODENEEDED = "To perform this operation a leaf node is needed";
        public const string ERRMSG_TREANODECANNOTBENULL = "To perform this operation a node cannot be null";
        public const string ERRMSG_WROONGINDEX = "The specified index is wrong to perform this operation";
    }
}
