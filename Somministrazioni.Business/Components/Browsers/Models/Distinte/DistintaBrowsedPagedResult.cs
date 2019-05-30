using CCWeb.Business.Components.Browsers.Models.Distinte;
using Somministrazioni.Business.Components.Browsers.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCWeb.Business.Components.Browsers
{
    public sealed class DistintaBrowsedPagedResult
    {
        public PagedResultInfoBase PagedResultInfoBase
        {
            get
            {
                return _pagedResultInfoBase;
            }
        }

        public IList<DistintaBrowsed> ListDistinte
        {
            get
            {
                return _listDistinte.ToImmutableList();
            }
        }

        public static DistintaBrowsedPagedResult Of(IList<DistintaBrowsed> listDistinte, PagedResultInfoBase pagedResultInfoBase) {

            return new DistintaBrowsedPagedResult(listDistinte, pagedResultInfoBase);

        }

        DistintaBrowsedPagedResult(IList<DistintaBrowsed> listDistinte, PagedResultInfoBase pagedResultInfoBase)
        {
            _listDistinte = listDistinte ?? throw new ArgumentNullException(nameof(listDistinte));
            _pagedResultInfoBase = pagedResultInfoBase ?? throw new ArgumentNullException(nameof(pagedResultInfoBase));
        }

        readonly IList<DistintaBrowsed> _listDistinte;
        readonly PagedResultInfoBase _pagedResultInfoBase;
    }
}
