using log4net;
using Somministrazioni.BusinessFacade;
using Somministrazioni.Common.Constants;
using Somministrazioni.Web.Constants;
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
        public DistinteController(ILog log, IBusinessFacade businessFacade)
        {
            _log = log;
            _businessFacade = businessFacade;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var distintePageModel = new DistintePageModel();
            var distinteBrowsedPagedResult = _businessFacade.Distinte(distintePageModel.ToFilter());
            distintePageModel.ListDistintaBrowsed = distinteBrowsedPagedResult.ListDistinte;

            return View(distintePageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DistintePageModel distinteModel)
        {

            var distinteBrowsedPagedResult = _businessFacade.Distinte(distinteModel.ToFilter());

            distinteModel.ListDistintaBrowsed = distinteBrowsedPagedResult.ListDistinte;
            _log.Info(WebConstants.INFOMSG_SHOWDATA);            

            return View(distinteModel);
        }

        readonly ILog _log;
        readonly IBusinessFacade _businessFacade; 
    }
}