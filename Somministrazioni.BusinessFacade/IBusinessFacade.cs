using CCWeb.Business.Components.Browsers;
using Somministrazioni.Business.Components.Browsers.Models;
using Somministrazioni.Business.Components.Browsers.Models.Contratto;
using Somministrazioni.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.BusinessFacade
{
    public interface IBusinessFacade
    {
        bool TryAuthenticateUser(string userName, string password, out string idOperatore);
        DistintaBrowsedPagedResult Distinte(DistintaFilter filtroRicerca);
        ContrattoBrowsedPagedResult Contratti(ContrattoFilter filtroRicerca);
    }
}
