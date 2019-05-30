using Somministrazioni.Business.Components.Browsers.Models.Contratto;
using Somministrazioni.Common.Filters;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Web;

namespace Somministrazioni.Web.Models.Contratti
{
    public class ContrattiPageModel : PageModelBase
    {
        public ContrattiPageModel()
        {
        }

        public ContrattiPageModel(string message, bool hasInfoPanel) : base(hasInfoPanel)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public IList<ContrattoBrowsed> ListContrattiBrowsed
        {
            get
            {
                return _listContrattoBrowsed.ToImmutableList();
            }
            set
            {
                _listContrattoBrowsed = value;
            }
        }


        public string Field1
        {
            get; set;
        }
        public string Field2
        {
            get; set;
        }

        public string Message { get; set; }

        public ContrattoFilter ToFilter()
        {
            return ContrattoFilter.Of(SortBy, SortDirection, CurrentPageNumb, PageSize);
        }

        IList<ContrattoBrowsed> _listContrattoBrowsed;
    }
}