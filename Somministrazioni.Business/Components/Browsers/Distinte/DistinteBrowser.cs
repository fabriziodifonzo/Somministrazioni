using CCWeb.Business.Components.Browsers;
using CCWeb.Business.Components.Browsers.Models.Distinte;
using EntityFramework.DbContextScope.Interfaces;
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
        public DistinteBrowser(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckConstructorParameters(ambientDbContextLocator);

            _ambientDbContextLocator = ambientDbContextLocator;
        }

        public DistintaBrowsedPagedResult BrowseDistinte(DistintaFilter filtroRicerca)
        {
            CheckBrowseDistinteParameters(filtroRicerca);

            var distinteDataService = DistinteDataServiceFactory.GetInstance(_ambientDbContextLocator);

            var numDistinte = distinteDataService.CountDistinte(filtroRicerca);
            var listDistinteFromDS = distinteDataService.BrowserDistinta(filtroRicerca);
            var listDistinteBrowsed = new List<DistintaBrowsed>();
            foreach (var distinta in listDistinteFromDS)
            {
                listDistinteBrowsed.Add(DistintaBrowsed.From(distinta));
            }

            var pageNumber = filtroRicerca.CurrentPageNumb;
            var pageSize = filtroRicerca.PageSize;

            return DistintaBrowsedPagedResult.Of(listDistinteBrowsed, PagedResultInfoBase.Of(pageNumber, pageSize, numDistinte));
        }

        readonly IAmbientDbContextLocator _ambientDbContextLocator;

        static void CheckConstructorParameters(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
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
