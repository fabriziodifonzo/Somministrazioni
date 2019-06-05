using EasyMaticaSrl.Utilities.Cryptography;
using EntityFramework.DbContextScope.Interfaces;
using log4net;
using Somministrazioni.Common.Constants;
using Somministrazioni.Data.Reporitories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService.User
{
    public class UsersDataService : DataServiceBase, IUsersDataService
    {
        public UsersDataService(ILog log, IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
            CheckConstructorParameters(log, ambientDbContextLocator);

            _log = log;
        }

        public bool TryAuthenticateUser(string userName, string password, out string idOperatore)
        {
            CheckTryAuthenticateUserParameter(userName, password);

            const bool VERIFYPASSWORDKO = false;

            var userRepository = UserRepositoryFactory.GetInstance(_ambientDbContextLocator);
            using (var context = _dbContextScopeFactory.CreateReadOnly())
            {
                var listOperatori = userRepository.OperatoreByUsername(userName);

                bool verifyPassword = VERIFYPASSWORDKO;
                idOperatore = null;
                if (listOperatori.Any())
                {
                    var operatore = listOperatori.First();
                    verifyPassword = PasswordEncryptor.VerifyPassword(password, operatore.Password);
                    idOperatore = operatore.Id.ToString();
                }

                return verifyPassword;
            }
        }

        ILog _log;

        static void CheckConstructorParameters(ILog log, IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (log == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(log));
            }
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
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
    }
}
