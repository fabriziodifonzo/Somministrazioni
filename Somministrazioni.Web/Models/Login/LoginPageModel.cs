using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Somministrazioni.Web.Models.Login
{
    public sealed class LoginPageModel : PageModelBase
    {
        public LoginPageModel()
        {
        }

        public LoginPageModel(bool authenticationOk, int errorCode, string errorMessage) : base (errorCode, errorMessage)
        {
            AuthenticationOk = authenticationOk;
        }

        public bool AuthenticationOk { get; set; }
    }
}