using Somministrazioni.Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Somministrazioni.Web.Controllers
{
    public class LogoutController : Controller
    {
        [HttpGet]
        public ActionResult Logout()
        {
            Session[WebConstants.SESSIONNAME_IDOPERATORE] = null;

            return View();
        }
    }
}