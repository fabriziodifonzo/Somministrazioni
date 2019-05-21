using Somministrazioni.Data.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Data.Reporitories.User
{
    public interface IUserRepository
    {
        IList<Operatore> OperatoreByUsername(string userName);
    }
}
