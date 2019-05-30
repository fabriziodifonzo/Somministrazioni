using Somministrazioni.Business.Components.Browsers.Models.Contratto;
using Somministrazioni.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Browsers.Contratti
{
    public interface IContrattiBrowser
    {
       ContrattoBrowsedPagedResult BrowseContratti(ContrattoFilter filtroRicerca);
    }
}
