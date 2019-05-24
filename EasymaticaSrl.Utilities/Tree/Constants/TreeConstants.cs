using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree.Constants
{
    public static class TreeConstants
    {
        //---- Error codes ---

        public const int ERRCODE_TREEALREADYHASAPARENT = 0;
        public const int ERRCODE_LEAFNODENEEDED = 1;
        public const int ERRCODE_TREENODECANNOTBENULL = 2;
        public const int ERRCODE_INVALIDNODENUMBER = 3;
        public const int ERRCODE_ONELEVELABOVEISNEEDEDFORATTACH = 3;
        public const int ERRCODE_ATTACHEDNODENEEDED = 4;
        public const int ERRCODE_INSERTEDNODENEEDED = 5;
        public const int ERRCODE_LEAFANDROOTNODENEEDED = 6;
        public const int ERRCODE_NODENUMBERNTFOUND = 7;

        //---- Error messages ---

        public const string ERRMSG_TREEALREADYHASAPARENT = "The tree already has a parent";
        public const string ERRMSG_LEAFNODENEEDED = "To perform this operation a leaf node is needed";
        public const string ERRMSG_TREANODECANNOTBENULL = "To perform this operation a node cannot be null";
        public const string ERRMSG_INVALIDNODENUMBER = "The nodeNumber have to greatee than one";
        public const string ERRMSG_ONELEVELABOVEISNEEDEDFORATTACH = "One level above is needed for attach";
        public const string ERRMSG_ATTACHEDNODENEEDED = "To perform this operation a node with ATTACHED status is needed";
        public const string ERRMSG_INSERTEDNODENEEDED = "To perform this operation a node with INSERTED status is needed";
        public const string ERRMSG_LEAFANDROOTNODENEEDED = "To perform this operation a leaf node ant ROOT status is needed";
        public const string ERRMSG_NODENUMBERNTFOUND = "The requested node number has not been found";
    }
}
