using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService.User
{
    public static class UserDataServiceFactory
    {
        public static UserDataService GetInstance(IAmbientDbContextLocator ambientContextLocator)
        {
            CheckGetInstanceParameters(ambientContextLocator);

            return new UserDataService(ambientContextLocator);
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
