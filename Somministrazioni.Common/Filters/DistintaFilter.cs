using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Common.Filters
{
    public sealed class DistintaFilter : FilterBase
    {
        public static DistintaFilter Of(string sortBy, string sortDirection, int currentPageIndex, int pageSize)
        {
            return new DistintaFilter(sortBy, sortDirection, currentPageIndex, pageSize);
        }

        DistintaFilter(String sortBy, string sortDirection, int currentPageIndex, int pageSize) : base(sortBy, sortDirection, currentPageIndex, pageSize)
        {
            CheckConstructorParameter(sortBy, sortDirection);
        }

        static void CheckConstructorParameter(String sortBy, string sortDirection)
        {
            if (sortBy == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(sortBy));
            }

            if (sortDirection == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(sortDirection));
            }
        }
    }
}
