using log4net;
using Somministrazioni.BusinessFacade;
using Somministrazioni.Common.Constants;
using Somministrazioni.Web.Constants;
using Somministrazioni.Web.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace Somministrazioni.Web.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(ILog log, IBusinessFacade businessFacade)
        {
            _log = log;
            _businessFacade = businessFacade;
        }
       
        [HttpGet]
        public ActionResult Index()
        {
            var loginPageModel = new LoginPageModel();
            _log.Info(WebConstants.INFOMSG_SHOWDATA);            

            return View(loginPageModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(LoginPageModel loginPageModel)
        {
            return Json(loginPageModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            CheckLoginParameters(userName, password);

            var authenticationRes = _businessFacade.TryAuthenticateUser(userName, password, out string idOperatore);

            if (authenticationRes == AUTHENTICATION_FALSE)
            {
                return Json(new LoginPageModel(AUTHENTICATION_FALSE, GenericConstants.ERRCODE_INVALIDLOGIN, GenericConstants.ERRMSG_INVALIDLOGIN));
            }
            PutInSession(this, idOperatore);

            return Json(new LoginPageModel(AUTHENTICATION_TRUE, GenericConstants.ERRCODE_OK, string.Empty));
        }

        readonly ILog _log;
        readonly IBusinessFacade _businessFacade;
        readonly static bool AUTHENTICATION_TRUE = true;
        static readonly bool AUTHENTICATION_FALSE = false;

        static void PutInSession(Controller controller, string idOperatore)
        {
            controller.Session[WebConstants.SESSIONNAME_IDOPERATORE] = idOperatore;
        }

        static void CheckLoginParameters(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(userName));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(password));
            }
        }
    }
}
