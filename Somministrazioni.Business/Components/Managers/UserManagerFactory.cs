using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Managers
{
    public static class UserManagerFactory
    {
        public static IUserManager GetInstance(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckGetInstanceParameters(ambientDbContextLocator);

            return new UserManager(ambientDbContextLocator);
        }

        static void CheckGetInstanceParameters(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
            }
        }
    }
}
