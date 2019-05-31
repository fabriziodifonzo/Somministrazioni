using CCWeb.Business.Components.Browsers.Models;
using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Business.Components.Browsers.Models.Contratto;
using Somministrazioni.Common.Constants;
using Somministrazioni.Common.Filters;
using Sommnistrazioni.Data.DataService.Contratti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Browsers.Contratti
{
    public class ContrattiBrowser : IContrattiBrowser
    {
        public ContrattiBrowser(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckConstructorParameters(ambientDbContextLocator);

            _ambientDbContextLocator = ambientDbContextLocator;
        }

        public ContrattoBrowsedPagedResult BrowseContratti(ContrattoFilter filtroRicerca)
        {
            CheckBrowseDistinteParameters(filtroRicerca);

            var contrattiDataService = ContrattiDataServiceFactory.GetInstance(_ambientDbContextLocator);

            var numContratti = contrattiDataService.CountDistinte(filtroRicerca);
            var listContrattiFromDS = contrattiDataService.BrowseContratti(filtroRicerca);
            var listContrattoBrowsed = new List<ContrattoBrowsed>();
            foreach (var contratto in listContrattiFromDS)
            {
                listContrattoBrowsed.Add(ContrattoBrowsed.From(contratto));
            }

            var pageNumber = filtroRicerca.CurrentPageNumb;
            var pageSize = filtroRicerca.PageSize;

            return ContrattoBrowsedPagedResult.Of(listContrattoBrowsed, PagedResultInfoBase.Of(pageNumber, pageSize, numContratti));            
        }


        readonly IAmbientDbContextLocator _ambientDbContextLocator;

        static void CheckConstructorParameters(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
            }
        }

        static void CheckBrowseDistinteParameters(ContrattoFilter filtroRicerca)
        {
            if (filtroRicerca == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filtroRicerca));
            }
        }

    }
}
