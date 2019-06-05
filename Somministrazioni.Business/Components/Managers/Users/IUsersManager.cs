using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Somministrazioni.Business.Components.Managers.Users
{
    public interface IUsersManager
    {
        bool TryAuthenticateUser(string userName, string password, out string idOperatore);
    }
}
