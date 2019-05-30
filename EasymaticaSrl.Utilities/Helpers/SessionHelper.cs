using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class SessionHelper
    {

        public static bool IsUserAuthenticated(object userId)
        {

            const bool USERAUTHENTICATED_OK = true;
            const bool USERAUTHENTICATED_KO = false;

            bool userAuthenticated = USERAUTHENTICATED_OK;
            if (userId == null) {
                userAuthenticated = USERAUTHENTICATED_KO;
            }

            return userAuthenticated;

        }

    }
}
