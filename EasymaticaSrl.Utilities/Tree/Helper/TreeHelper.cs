using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Tree.Helper
{
    public static class TreeHelper
    {
        public static string PrintPath(string[] listNodeLabel, char separator)
        {
            CheckPrintPathParameters(listNodeLabel);

            var pathBuilder = new StringBuilder();
            foreach (var nodeLabel in listNodeLabel)
            {
                pathBuilder.Append(nodeLabel).Append(separator);
            }
            pathBuilder.Remove(pathBuilder.ToString().Count()-1, 1);

            return pathBuilder.ToString();
        }

        static void CheckPrintPathParameters(string[] listPath)
        {
            if (listPath == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(listPath));
            }
            if (!listPath.Any())
            {
                throw new ArgumentException(GenericConstants.ERRMSG_LISTEMPTY + GenericConstants.CHR_SPACE + nameof(listPath));
            }
        }
    }
}
