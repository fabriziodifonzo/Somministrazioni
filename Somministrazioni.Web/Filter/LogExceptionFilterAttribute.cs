using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Somministrazioni.Web.Filter
{
    public class LogExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public LogExceptionFilterAttribute(ILog log)
        {
            _log = log;
        }

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null && filterContext.Exception != null)
            {
                _log.Info(filterContext.Exception);
            }
        }

        readonly ILog _log;
    }
}