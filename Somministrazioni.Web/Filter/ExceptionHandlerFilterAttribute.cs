using log4net;
using Somministrazioni.Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Somministrazioni.Web.Filter
{
    public class ExceptionHandlerFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public ExceptionHandlerFilterAttribute(ILog log)
        {
            _log = log;
        }

        public void OnException(ExceptionContext exceptionContext)
        {
            if (exceptionContext != null && exceptionContext.Exception != null)
            {
                _log.Info(exceptionContext.Exception);

                if (exceptionContext.HttpContext.Request.IsAjaxRequest())
                {
                    throw exceptionContext.Exception;
                }
                else
                {
                    exceptionContext.ExceptionHandled = true;
                    exceptionContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary
                            {
                                { WebConstants.ROUTEVALUEINDEXKEY_CONTROLLER, WebConstants.CONTROLLERNAME_ERROR },
                                { WebConstants.ROUTEVALUEINDEXKEY_ACTION, WebConstants.ACTIONNAME_ERROR_INDEX }
                            }
                        );
                }
            }
        }

        readonly ILog _log;
    }
}