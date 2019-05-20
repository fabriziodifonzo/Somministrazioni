using log4net;
using Somministrazioni.BusinessFacade;
using Somministrazioni.Common.Constants;
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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password)
        {
            try
            {
                CheckLoginParameters(userName, password);

                _log.Info((new StringBuilder(nameof(Login))).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_START));

                var businessFacade = BusinessFacadeFactory.GetInstance();
                var authenticationRes = businessFacade.TryAuthenticateUser(userName, password, out string idOperatore);
                var actionInfo = ViewSelectorFactory.GetInstance(authenticationRes).SelectView();

                if (authenticationRes == AUTHENTICATION_FALSE)
                {
                    return RedirectToAction(actionInfo.ActionName, actionInfo.ControllerName);
                }
                PutInSession(this, idOperatore);

                _log.Info((new StringBuilder(nameof(Login))).Append(GenericConstants.CHR_SPACE).Append(GenericConstants.METHOD_END));

                return RedirectToAction(actionInfo.ActionName, actionInfo.ControllerName);
            }
            catch (Exception e)
            {
                _log.Info(e);
                return RedirectToAction(GenericConstants.ACTIONNAME_ERROR_INDEX, GenericConstants.CONTROLLERNAME_ERROR);
            }
        }

        static void PutInSession(Controller controller, string idOperatore)
        {
            controller.Session[GenericConstants.SESSIONNAME_IDOPERATORE] = idOperatore;
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

        readonly ILog _log = log4net.LogManager.GetLogger(typeof(LoginController));
        readonly static bool AUTHENTICATION_TRUE = true;
        static readonly bool AUTHENTICATION_FALSE = false;

        class ActionInfo
        {
            public static ActionInfo Of(string controllerName, string actionName)
            {
                CheckOfParameters(controllerName, actionName);

                return new ActionInfo(controllerName, actionName);
            }

            public string ControllerName { get { return _controllerName; } }
            public string ActionName { get { return _actionName; } }

            ActionInfo(string controllerName, string actionName)
            {
                _controllerName = controllerName;
                _actionName = actionName;
            }

            readonly string _controllerName;
            readonly string _actionName;

            private static void CheckOfParameters(string controllerName, string actionName)
            {
                if (string.IsNullOrWhiteSpace(controllerName))
                {
                    throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(controllerName));
                }
                if (string.IsNullOrWhiteSpace(actionName))
                {
                    throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(actionName));
                }
            }
        }

        interface IViewSelector
        {
            ActionInfo SelectView();
        }

        class LoginViewSelector : IViewSelector
        {
            public ActionInfo SelectView()
            {
                return ActionInfo.Of(GenericConstants.CONTROLLERNAME_LOGIN, GenericConstants.ACTIONNAME_LOGIN_INDEX);
            }
        }

        class ApplicationHomeViewSelector : IViewSelector
        {
            public ActionInfo SelectView()
            {
                return ActionInfo.Of(GenericConstants.CONTROLLERNAME_APPLICATIONHOME, GenericConstants.ACTIONNAME_APPLICATIONHOME_INDEX);
            }
        }

        static class ViewSelectorFactory
        {            
            public static IViewSelector GetInstance(bool autenticationOk)
            {
                if (autenticationOk == AUTHENTICATION_TRUE)
                {
                    return new ApplicationHomeViewSelector();
                }
                else
                {
                    return new LoginViewSelector();
                }

            }
        }
    }
}
