using log4net;
using Somministrazioni.Common.Constants;
using Somministrazioni.Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Somministrazioni.Web.Filter
{
    public class LogActionFilterAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public LogActionFilterAttribute(ILog log)
        {
            _log = log;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var methodType = filterContext.HttpContext.Request.HttpMethod;
            var name = $"{filterContext.ActionDescriptor.ControllerDescriptor.ControllerType}.{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}.{filterContext.ActionDescriptor.ActionName}";
            var args = filterContext.ActionDescriptor.GetParameters().ToArray();

            _log.Info($"Calling: {name} {methodType}");
            _log.Info($"Args: {args}");

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var methodType = filterContext.HttpContext.Request.HttpMethod;
            var name = $"{filterContext.ActionDescriptor.ControllerDescriptor.ControllerType}.{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}.{filterContext.ActionDescriptor.ActionName}";

            _log.Info(($"Done ({name}) {methodType}"));

            base.OnActionExecuted(filterContext);
        }

        readonly ILog _log;
    }
}