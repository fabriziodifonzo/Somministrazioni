using EntityFramework.DbContextScope.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Managers
{
    public abstract class UserManagerBase : IUserManager
    {
        protected UserManagerBase(IAmbientDbContextLocator ambientDbContextLocator)
        {
            _ambientDbContextLocator = ambientDbContextLocator ?? throw new ArgumentNullException(nameof(ambientDbContextLocator));
        }

        public abstract bool TryAuthenticateUser(string userName, string password, out string idOperatore);

        protected readonly IAmbientDbContextLocator _ambientDbContextLocator;       
    }
}
