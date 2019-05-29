using EasymaticaSrl.Utilities.Contract.Exceptions;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasymaticaSrl.Utilities.Contract
{
    public static class Contract
    {
        public static void PreCondiction(Boolean assertion)
        {
            if (!assertion)
            {
                throw new ContractException(GenericConstants.ERRMSG_PRECONDICTION);
            }
        }

        public static void Precondiction(Boolean assertion, string msg)
        {
            if (!assertion)
            {
                throw new ContractException((new StringBuilder(GenericConstants.ERRMSG_PRECONDICTION)).Append(GenericConstants.CHR_SPACE).Append(msg).ToString());
            }
        }

        public static void PostCondiction(Boolean assertion)
        {
            if (!assertion)
            {
                throw new ContractException(GenericConstants.ERRMSG_PRECONDICTION);
            }
        }

        public static void PostCondiction(Boolean assertion, string msg)
        {
            if (!assertion)
            {
                throw new ContractException((new StringBuilder(GenericConstants.ERRMSG_PRECONDICTION)).Append(GenericConstants.CHR_SPACE).Append(msg).ToString());
            }
        }
    }
}
