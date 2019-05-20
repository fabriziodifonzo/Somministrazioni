using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.BusinessFacade
{
    public interface IBusinessFacade
    {
        bool TryAuthenticateUser(string userName, string password, out string idOperatore);
    }
}
