using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EasyMaticaSrl.Utilities.Cryptography
{

    //This class contains methods to hash and verify password by using Bcript encryption algorithm.
    //
    //
    public static class PasswordEncryptor
    {

        public static string HashPassword(string passwordToHash) {

            CheckHashPasswordParameters(passwordToHash);

            return BCrypt.Net.BCrypt.HashPassword(passwordToHash);

        }


        public static bool VerifyPassword(string passwordText, string passwordHash)
        {

            CheckVerifyPasswordParameters(passwordText, passwordHash);
            
            return BCrypt.Net.BCrypt.Verify(passwordText, passwordHash);

        }

        private static void CheckVerifyPasswordParameters(string passwordText, string passwordHash) {

            if (string.IsNullOrEmpty(passwordText))
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + " " + nameof(passwordText));
            }

            if (string.IsNullOrEmpty(passwordHash))
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + " " + nameof(passwordHash));
            }

        }

        private static void CheckHashPasswordParameters(string password) {

            if (string.IsNullOrEmpty(password)) {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLOREMPTYARGUMENT + " " + nameof(password));
            }

        }
    }
}
