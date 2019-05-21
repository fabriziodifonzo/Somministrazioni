using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Data.Reporitories.User
{
    public static class UserRepositoryFactory
    {
        public static IUserRepository GetInstance(IAmbientDbContextLocator ambientContextLocator)
        {
            CheckGetInstanceParameters(ambientContextLocator);

            return new UserRepository(ambientContextLocator);
        }

        static void CheckGetInstanceParameters(IAmbientDbContextLocator ambientContextLocator)
        {
            if (ambientContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientContextLocator));
            }
        }
    }
}
