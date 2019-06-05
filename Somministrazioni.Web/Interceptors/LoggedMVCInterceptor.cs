using Castle.DynamicProxy;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Somministrazioni.Web.Interceptors
{
    public class LoggedMvcInterceptor : IInterceptor
    {
        public LoggedMvcInterceptor(ILog log)
        {
            _log = log;
        }
 
        public void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";
            var args = string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()));

            _log.Info($"Calling: {name}");
            _log.Info($"Args: {args}");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            invocation.Proceed(); //Intercepted method is executed here.
            watch.Stop();
            var executionTime = watch.ElapsedMilliseconds;

            _log.Info($"Done: result was {invocation.ReturnValue}");
            _log.Info($"Execution Time: {executionTime} ms.");
          
        }

        readonly ILog _log;
    }
}