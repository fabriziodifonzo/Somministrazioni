using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;
using log4net;
using Somministrazioni.Common.Constants;
using Sommnistrazioni.Data.DataService.User;

namespace Somministrazioni.Business.Components.Managers.Users
{
    public class UsersManager : IUsersManager
    {
        public UsersManager(ILog log, IUsersDataService userDataService)
        {
            CheckConstructorParameters(log, userDataService);

            _log = log;
            _userDataService = userDataService;
        }

        public bool TryAuthenticateUser(string userName, string password, out string idOperatore)
        {
            CheckTryAuthenticateUserParameter(userName, password);

            return _userDataService.TryAuthenticateUser(userName, password, out idOperatore);
        }

        static void CheckConstructorParameters(ILog log, IUsersDataService userDataService)
        {
            if (log == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(log));
            }
            if (userDataService == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(userDataService));
            }
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

        readonly ILog _log;
        readonly IUsersDataService _userDataService;
    }
}
