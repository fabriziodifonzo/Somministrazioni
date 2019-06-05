using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService.User
{
    public interface IUsersDataService
    {
        bool TryAuthenticateUser(string userName, string password, out string idOperatore);
    }
}
