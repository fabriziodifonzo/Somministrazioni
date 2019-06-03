using log4net;
using Somministrazioni.Common.Constants;
using Somministrazioni.Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Somministrazioni.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(WebConstants.HTTPMETHODTYPE_GET).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            _log.Info((new StringBuilder(nameof(Index))).Append(GenericConstants.CHR_SPACE).Append(WebConstants.HTTPMETHODTYPE_GET).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        readonly ILog _log = log4net.LogManager.GetLogger(typeof(HomeController));

    }
}