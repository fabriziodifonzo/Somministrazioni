using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Somministrazioni.Web.Constants
{
    public static class WebConstants
    {
        //---- Info message ----

        public const string INFOMSG_SHOWDATA = "Returning HTML page showing data";

        //----- Pages -----

        public const int PAGESISZE_DEFAULT = 10;
        public const int PAGENUMB_DEFAULT = 1;

        //----- Web method types -----

        public const string HTTPMETHODTYPE_GET = "GET";
        public const string HTTPMETHODTYPE_POST = "POST";

        //--- Controller Names ----

        public const string CONTROLLERNAME_APPLICATIONHOME = "Home";
        public const string CONTROLLERNAME_LOGIN = "Login";
        public const string CONTROLLERNAME_ERROR = "Error";
        public const string CONTROLLERNAME_DISTINTE = "Distinte";
        public const string CONTROLLERNAME_CONTRATTI = "Contratti";

        //--- Action names ---

        public const string ACTIONNAME_APPLICATIONHOME_INDEX = "Index";
        public const string ACTIONNAME_LOGIN_INDEX = "Index";
        public const string ACTIONNAME_ERROR_INDEX = "Index";
        public const string ACTIONNAME_DISTINTE_INDEX = "Index";
        public const string ACTIONNAME_CONTRATTI_INDEX = "Index";

        //--- Session Names ----

        public const string SESSIONNAME_IDOPERATORE = "idoperatore";

    }
}