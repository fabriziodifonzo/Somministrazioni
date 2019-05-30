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

        public LoginPageModel(string message , bool hasInfoPanel) : base (hasInfoPanel)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public string Message { get; set; }
    }
}