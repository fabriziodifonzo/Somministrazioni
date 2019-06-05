using log4net;
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
        public ContrattiController(ILog log, IBusinessFacade businessFacade)
        {
            _log = log;
            _businessFacade = businessFacade;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _log.Info((new StringBuilder(WebConstants.HTTPMETHODTYPE_GET)).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            var contrattiPageModel = new ContrattiPageModel();
            var contrattiBrowsedPagedResult = _businessFacade.Contratti(contrattiPageModel.ToFilter());
            contrattiPageModel.ListContrattiBrowsed = contrattiBrowsedPagedResult.ListContratti;

            _log.Info((new StringBuilder(WebConstants.HTTPMETHODTYPE_GET)).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_END));

            return View(contrattiPageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContrattiPageModel contrattiModel)
        {
            _log.Info((new StringBuilder(WebConstants.HTTPMETHODTYPE_POST)).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            var contrattiBrowsedPagedResult = _businessFacade.Contratti(contrattiModel.ToFilter());

            contrattiModel.ListContrattiBrowsed = contrattiBrowsedPagedResult.ListContratti;

            _log.Info((new StringBuilder(WebConstants.HTTPMETHODTYPE_POST)).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_END));

            return View(contrattiModel);
        }

        readonly IBusinessFacade _businessFacade;
        readonly ILog _log;
    }
}