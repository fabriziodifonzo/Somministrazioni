using EasyMaticaSrl.Utilities.Cryptography;
using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using Somministrazioni.Data.Reporitories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService.User
{
    public class UserDataService : DataServiceBase, IUserDataService
    {
        public UserDataService(IAmbientDbContextLocator ambientDbContextLocator) : base(ambientDbContextLocator)
        {
        }

        public bool TryAuthenticateUser(string userName, string password, out string idOperatore)
        {
            CheckTryAuthenticateUserParameter(userName, password);

            const bool VERIFYPASSWORDKO = false;

            int FIRST_ELEMENT = 0;
            var userRepository = UserRepositoryFactory.GetInstance(_ambientDbContextLocator);
            using (var context = _dbContextScopeFactory.CreateReadOnly())
            {
                var listOperatori = userRepository.OperatoreByUsername(userName);

                bool verifyPassword = VERIFYPASSWORDKO;
                idOperatore = null;
                if (listOperatori.Any())
                {
                    var operatore = listOperatori.ElementAt(FIRST_ELEMENT);                    
                    verifyPassword = PasswordEncryptor.VerifyPassword(password, operatore.Password);
                    idOperatore = operatore.Id.ToString();
                }

                return verifyPassword;
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
