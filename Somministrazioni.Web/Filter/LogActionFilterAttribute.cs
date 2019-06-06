using log4net;
using Somministrazioni.Common.Constants;
using Somministrazioni.Web.Constants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var args = ParameterHelper.PrintParameters(filterContext.ActionParameters);


            _log.Info($"Calling: {name} {methodType}");
            _log.Info($"Args: {args}");

            watch = new Stopwatch();
            watch.Start();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            watch.Stop();
            var methodType = filterContext.HttpContext.Request.HttpMethod;
            var name = $"{filterContext.ActionDescriptor.ControllerDescriptor.ControllerType}.{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}.{filterContext.ActionDescriptor.ActionName}";
            var executionTime = watch.ElapsedMilliseconds;

            _log.Info(($"Done ({name}) {methodType}"));
            _log.Info($"Execution Time: {executionTime} ms.");
        }

        Stopwatch watch;
        readonly ILog _log;

        static class ParameterHelper
        {
            public static string PrintParameters(IDictionary<string, object> mapParameters)
            {
                var paramBuilder = new StringBuilder();
                foreach (var paramDescriptor in mapParameters)
                {
                    paramBuilder.Append(paramDescriptor.Value);
                    paramBuilder.Append(",");
                }
                if (paramBuilder.Length > 0)
                {
                    paramBuilder.Remove(paramBuilder.Length - 1, 1);
                }
                
                return paramBuilder.ToString();
            }
        }
    }
}