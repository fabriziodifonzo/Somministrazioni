using Somministrazioni.Business.Components.Browsers.Models;
using Somministrazioni.Common.Filters;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Web;

namespace Somministrazioni.Web.Models.Distinte
{
    public class DistinteModel : ModelBase
    {
        public DistinteModel() 
        {
        }

        public DistinteModel(string message, bool hasInfoPanel) : base(hasInfoPanel)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public IList<DistintaBrowsed> ListDistintaBrowsed
        {
            get {
                return _listDistintaBrowsed.ToImmutableList();
            }
            set {
                _listDistintaBrowsed = value;
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

        public DistintaFilter ToFilter()
        {
            return DistintaFilter.Of(SortBy, SortDirection, CurrentPageIndex, PageSize);
        }

        IList<DistintaBrowsed> _listDistintaBrowsed;
    }
}