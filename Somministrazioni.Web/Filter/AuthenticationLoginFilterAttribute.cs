using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Somministrazioni.Web.Filter
{
    public class AuthenticationLoginFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        { 
            //Login page must be accessed by every user so this method is empty.
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //Login page must be accessed by every user so this method is empty.
        }
    }
}