using CCWeb.Business.Components.Browsers;
using Somministrazioni.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Browsers.Distinte
{
    public interface IDistinteBrowser
    {
        DistintaBrowsedPagedResult BrowseDistinte(DistintaFilter filtroRicerca);
    }
}
