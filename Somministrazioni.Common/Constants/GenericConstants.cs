using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Common.Constants
{
    public static class GenericConstants
    {
        //---- Error Messages ----

        public const string ERRMSG_NULLARGUMENT = "The following argument must not be null ";
        public const string ERRMSG_EMPTYARGUMENT = "The following argument must not be empty ";
        public const string ERRMSG_NULLOREMPTYARGUMENT = "The following argument must not be empty null nor empty ";
        public const string ERRMSG_AMBIENTDBCONTEXT = "No ambient DbContext of type {0} found.This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.";
        public const string ERRMSG_INVALIDDATATYPE = "Tipo di dato non valido. ";
        public const string ERRMSG_PRECONDICTION = "Precondizione violata";

        //--- Controller Names ----

        public const string CONTROLLERNAME_APPLICATIONHOME = "Home";
        public const string CONTROLLERNAME_LOGIN = "Login";
        public const string CONTROLLERNAME_ERROR = "Error";

        //--- Action names ---

        public const string ACTIONNAME_APPLICATIONHOME_INDEX = "Index";
        public const string ACTIONNAME_LOGIN_INDEX = "Index";
        public const string ACTIONNAME_ERROR_INDEX = "Index";

        //--- Session Names ----

        public const string SESSIONNAME_IDOPERATORE = "idoperatore";

        //---- Log4Net appenders ------

        public const string QUERY_APPENDER = "Query";

        //---- Flags -----

        public const short FLAG_ISACTIVESHORT = 1;
        public const short FLAG_ISNOTACTIVESHORT = 0;
        public const bool FLAG_ISACTIVE = true;
        public const bool FLAG_ISNOTACTIVE = false;

        //--- Log -----------

        public const string LOG_PARAMETERNAME = "NAME =";
        public const string LOG_PARAMETERVALUE = "VALUE =";

        //----- Generic ------

        public const char CHR_DOUBLEQUOTES = '"';
        public const string CHR_HYPEN = "-";
        public const string CHR_SPACE = " ";
        public const string CHR_COMMA = ",";
        public const string CHR_EQUALS = "=";
        public const string CHR_LIKE = "%";
        public const string BRACKET_CURLYOPEN = "{";
        public const string BRACKET_CURLYCLOSED = "}";
        public const string DATAENCRYPTION_PASSPHRASE = "Easymatica2018";
        public const string METHOD_START = "Start";
        public const string METHOD_END = "End";
    }
}
