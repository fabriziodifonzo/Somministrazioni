using log4net;
using Somministrazioni.BusinessFacade;
using Somministrazioni.Common.Constants;
using Somministrazioni.Web.Models.Distinte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Somministrazioni.Web.Controllers
{
    public class DistinteController : Controller
    {
        public ActionResult Index()
        {
            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            DistinteModel distinteModel = new DistinteModel();

            var factory = BusinessFacadeFactory.GetInstance();
            var distinteBrowsedPagedResult = factory.Distinte(distinteModel.ToFilter());

            distinteModel.ListDistintaBrowsed = distinteBrowsedPagedResult.ListDistinte;

            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_END));

            return View(distinteModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DistinteModel distinteModel)
        {
            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            var factory = BusinessFacadeFactory.GetInstance();
            var distinteBrowsedPagedResult = factory.Distinte(distinteModel.ToFilter());

            distinteModel.ListDistintaBrowsed = distinteBrowsedPagedResult.ListDistinte;

            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_END));

            return View(distinteModel);
        }

        readonly ILog _log = log4net.LogManager.GetLogger(typeof(LoginController));
    }
}