using Somministrazioni.BusinessFacade;
using Somministrazioni.Common.Constants;
using Somministrazioni.Web.Constants;
using Somministrazioni.Web.Models.Contratti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Somministrazioni.Web.Controllers
{
    public class ContrattiController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(WebConstants.HTTPMETHODTYPE_GET).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            ContrattiPageModel contrattiPageModel = new ContrattiPageModel();
            var businessFacade = BusinessFacadeFactory.GetInstance();
            var contrattiBrowsedPagedResult = businessFacade.Contratti(contrattiPageModel.ToFilter());
            contrattiPageModel.ListContrattiBrowsed = contrattiBrowsedPagedResult.ListContratti;

            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(WebConstants.HTTPMETHODTYPE_GET).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_END));

            return View(contrattiPageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContrattiPageModel contrattiModel)
        {
            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(WebConstants.HTTPMETHODTYPE_POST).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            var businessFacade = BusinessFacadeFactory.GetInstance();
            var contrattiBrowsedPagedResult = businessFacade.Contratti(contrattiModel.ToFilter());

            contrattiModel.ListContrattiBrowsed = contrattiBrowsedPagedResult.ListContratti;

            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(WebConstants.HTTPMETHODTYPE_POST).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_END));

            return View(contrattiModel);
        }

        readonly ILog _log = log4net.LogManager.GetLogger(typeof(LoginController));
    }
}