using CCWeb.Business.Components.Browsers;
using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Business.Components.Browsers.Distinte;
using Somministrazioni.Business.Components.Browsers.Models;
using Somministrazioni.Business.Components.Managers;
using Somministrazioni.Common.Constants;
using Somministrazioni.Common.Filters;
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

        public DistintaBrowsedPagedResult Distinte(DistintaFilter filtroRicerca)
        {
            CheckDistinteParameters(filtroRicerca);

            var distinteBrowser = DistinteBrowserFactory.GetInstance(_ambientDbContextLocator);

            return distinteBrowser.BrowseDistinte(filtroRicerca);
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

        static void CheckDistinteParameters(DistintaFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filter));
            }
        }

        readonly IAmbientDbContextLocator _ambientDbContextLocator;
    }
}
