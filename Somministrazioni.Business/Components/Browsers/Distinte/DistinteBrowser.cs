using CCWeb.Business.Components.Browsers;
using CCWeb.Business.Components.Browsers.Models;
using EntityFramework.DbContextScope.Interfaces;
using log4net;
using Somministrazioni.Business.Components.Browsers.Models;
using Somministrazioni.Common.Constants;
using Somministrazioni.Common.Filters;
using Sommnistrazioni.Data.DataService.Distinte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Browsers.Distinte
{
    public class DistinteBrowser : IDistinteBrowser
    {
        public DistinteBrowser(ILog log, IDistinteDataService distinteDataService)
        {
            CheckConstructorParameters(log, distinteDataService);

            _log = log;
            _distinteDataService = distinteDataService;
        }

        public DistintaBrowsedPagedResult BrowseDistinte(DistintaFilter filtroRicerca)
        {
            CheckBrowseDistinteParameters(filtroRicerca);

            var numDistinte = _distinteDataService.CountDistinte(filtroRicerca);
            var listDistinteFromDS = _distinteDataService.BrowseDistinte(filtroRicerca);
            var listDistinteBrowsed = new List<DistintaBrowsed>();
            foreach (var distinta in listDistinteFromDS)
            {
                listDistinteBrowsed.Add(DistintaBrowsed.From(distinta));
            }

            var pageNumber = filtroRicerca.CurrentPageNumb;
            var pageSize = filtroRicerca.PageSize;

            return DistintaBrowsedPagedResult.Of(listDistinteBrowsed, PagedResultInfoBase.Of(pageNumber, pageSize, numDistinte));
        }

        readonly ILog _log;
        readonly IDistinteDataService _distinteDataService;

        static void CheckConstructorParameters(ILog log, IDistinteDataService distinteDataService)
        {
            if (log == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(log));
            }
            if (distinteDataService == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(distinteDataService));
            }
        }

        static void CheckBrowseDistinteParameters(DistintaFilter filtroRicerca)
        {
            if (filtroRicerca == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filtroRicerca));
            }
        }
    }
}
