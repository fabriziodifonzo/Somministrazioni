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
            Session.Clear();  //Clears session data.
            Session.Abandon(); //Triggers the Session_OnEnd event.
            _clearSessionIDCookie();  //Destroy client side session.

            return View();
        }

        private void _clearSessionIDCookie()
        {
            var httpCookie = new HttpCookie(WebConstants.COOKIE_SESSIONID, string.Empty);
            httpCookie.HttpOnly = true;

            HttpContext.Response.Cookies.Add(httpCookie);
        }
    }
}