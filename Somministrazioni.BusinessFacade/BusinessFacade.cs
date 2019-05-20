using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Business.Components.Managers;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.BusinessFacade
{
    public sealed class BusinessFacade : IBusinessFacade
    {
        public BusinessFacade()
        {
            _ambientDbContextLocator = new AmbientDbContextLocator();
        }

        public bool TryAuthenticateUser(string userName, string password, out string idOperatore)
        {
            CheckTryAuthenticateUserParameter(userName, password);

            var userManager = UserManagerFactory.GetInstance(_ambientDbContextLocator);

            return userManager.TryAuthenticateUser(userName, password, out idOperatore);
        }

        static void CheckTryAuthenticateUserParameter(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(userName));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + GenericConstants.CHR_SPACE + nameof(password));
            }
        }

        readonly IAmbientDbContextLocator _ambientDbContextLocator;
    }
}
