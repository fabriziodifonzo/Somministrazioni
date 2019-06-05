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
            _log.Info((new StringBuilder(WebConstants.HTTPMETHODTYPE_GET)).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            _log.Info(WebConstants.INFOMSG_SHOWDATA);

            _log.Info((new StringBuilder(WebConstants.HTTPMETHODTYPE_GET)).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

            return View();
        }

        readonly ILog _log = log4net.LogManager.GetLogger(typeof(HomeController));

    }
}