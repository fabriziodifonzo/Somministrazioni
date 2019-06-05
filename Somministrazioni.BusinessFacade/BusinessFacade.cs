using CCWeb.Business.Components.Browsers;
using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using log4net;
using Somministrazioni.Business.Components.Browsers.Contratti;
using Somministrazioni.Business.Components.Browsers.Distinte;
using Somministrazioni.Business.Components.Browsers.Models;
using Somministrazioni.Business.Components.Browsers.Models.Contratto;
using Somministrazioni.Business.Components.Managers;
using Somministrazioni.Business.Components.Managers.Users;
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
        public BusinessFacade(ILog log, IDistinteBrowser distinteBrowser, IContrattiBrowser contrattiBrowser, IUsersManager usersManager)
        {
            CheckConstructorParameters(log, distinteBrowser, contrattiBrowser, usersManager);

            _log = log;
            _distinteBrowser = distinteBrowser;
            _contrattiBrowser = contrattiBrowser;
            _usersManager = usersManager;
        }

        public bool TryAuthenticateUser(string userName, string password, out string idOperatore)
        {
            CheckTryAuthenticateUserParameter(userName, password);

            return _usersManager.TryAuthenticateUser(userName, password, out idOperatore);
        }

        public DistintaBrowsedPagedResult Distinte(DistintaFilter filtroRicerca)
        {
            CheckDistinteParameters(filtroRicerca);
            
            return _distinteBrowser.BrowseDistinte(filtroRicerca);
        }

        public ContrattoBrowsedPagedResult Contratti(ContrattoFilter filtroRicerca)
        {
            CheckContrattiParameters(filtroRicerca);

            return _contrattiBrowser.BrowseContratti(filtroRicerca);
        }

        static void CheckConstructorParameters(ILog log, IDistinteBrowser distinteBrowser, IContrattiBrowser contrattiBrowser, IUsersManager usersManager)
        {
            if (log == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(log));
            }
            if (distinteBrowser == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(distinteBrowser));
            }
            if (contrattiBrowser == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(contrattiBrowser));
            }
            if (usersManager == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(usersManager));
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

        static void CheckDistinteParameters(DistintaFilter filtroRicerca)
        {
            if (filtroRicerca == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filtroRicerca));
            }
        }

        static void CheckContrattiParameters(ContrattoFilter filtroRicerca)
        {
            if (filtroRicerca == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filtroRicerca));
            }
        }

        readonly ILog _log;
        readonly IDistinteBrowser _distinteBrowser;
        readonly IContrattiBrowser _contrattiBrowser;
        readonly IUsersManager _usersManager;
    }
}
