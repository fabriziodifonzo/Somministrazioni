using Somministrazioni.Common.Constants;
using Somministrazioni.Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Somministrazioni.Web.Filter
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {            
            if (filterContext.HttpContext.Session[WebConstants.SESSIONNAME_IDOPERATORE] == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { WebConstants.ROUTEVALUEINDEXKEY_CONTROLLER, WebConstants.CONTROLLERNAME_LOGIN },
                        { WebConstants.ROUTEVALUEINDEXKEY_ACTION, WebConstants.ACTIONNAME_LOGIN_INDEX }
                    });
            }            
        }
    }
}