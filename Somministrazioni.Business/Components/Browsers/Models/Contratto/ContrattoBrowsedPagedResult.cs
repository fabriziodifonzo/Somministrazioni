using CCWeb.Business.Components.Browsers.Models;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Browsers.Models.Contratto
{
    public class ContrattoBrowsedPagedResult
    {
        public PagedResultInfoBase PagedResultInfoBase
        {
            get
            {
                return _pagedResultInfoBase;
            }
        }

        public IList<ContrattoBrowsed> ListContratti
        {
            get
            {
                return _listContratti.ToImmutableList();
            }
        }

        public static ContrattoBrowsedPagedResult Of(IList<ContrattoBrowsed> listContratti, PagedResultInfoBase pagedResultInfoBase)
        {
            CheckOfParameters(listContratti, pagedResultInfoBase);

            return new ContrattoBrowsedPagedResult(listContratti, pagedResultInfoBase);

        }

        ContrattoBrowsedPagedResult(IList<ContrattoBrowsed> listContratti, PagedResultInfoBase pagedResultInfoBase)
        {
            _listContratti = listContratti ?? throw new ArgumentNullException(nameof(listContratti));
            _pagedResultInfoBase = pagedResultInfoBase ?? throw new ArgumentNullException(nameof(pagedResultInfoBase));
        }

        readonly IList<ContrattoBrowsed> _listContratti;
        readonly PagedResultInfoBase _pagedResultInfoBase;

        static void CheckOfParameters(IList<ContrattoBrowsed> listContratti, PagedResultInfoBase pagedResultInfoBase)
        {
            if (listContratti == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(listContratti));
            }
            if (pagedResultInfoBase == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(pagedResultInfoBase));
            }
        }
    }
}
