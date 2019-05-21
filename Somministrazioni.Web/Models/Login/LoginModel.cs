using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Somministrazioni.Web.Models.Login
{
    public sealed class LoginModel : ModelBase
    {
        public LoginModel()
        {
        }

        public LoginModel(string message , bool hasInfoPanel) : base (hasInfoPanel)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public string Message { get; set; }
    }
}