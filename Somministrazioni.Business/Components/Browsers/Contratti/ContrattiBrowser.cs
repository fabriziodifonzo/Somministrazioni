using CCWeb.Business.Components.Browsers.Models;
using EntityFramework.DbContextScope.Interfaces;
using log4net;
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
        public ContrattiBrowser(ILog log, IContrattiDataService contrattiDataService)
        {
            CheckConstructorParameters(log, contrattiDataService);

            _log = log;
            _contrattiDataService = contrattiDataService;
        }

        public ContrattoBrowsedPagedResult BrowseContratti(ContrattoFilter filtroRicerca)
        {
            CheckBrowseDistinteParameters(filtroRicerca);

            var numContratti = _contrattiDataService.CountDistinte(filtroRicerca);
            var listContrattiFromDS = _contrattiDataService.BrowseContratti(filtroRicerca);
            var listContrattoBrowsed = new List<ContrattoBrowsed>();
            foreach (var contratto in listContrattiFromDS)
            {
                listContrattoBrowsed.Add(ContrattoBrowsed.From(contratto));
            }

            var pageNumber = filtroRicerca.CurrentPageNumb;
            var pageSize = filtroRicerca.PageSize;

            return ContrattoBrowsedPagedResult.Of(listContrattoBrowsed, PagedResultInfoBase.Of(pageNumber, pageSize, numContratti));            
        }


        readonly ILog _log;
        readonly IContrattiDataService _contrattiDataService;

        static void CheckConstructorParameters(ILog log, IContrattiDataService contrattiDataService)
        {
            if (log == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(log));
            }
            if (contrattiDataService == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(contrattiDataService));
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
