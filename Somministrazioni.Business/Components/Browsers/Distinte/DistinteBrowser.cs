using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using Somministrazioni.Common.Filters;
using Sommnistrazioni.Data.DataService.Distinte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Browsers.Distinte
{
    public class DistinteBrowser : IDistinteBrowser
    {
        public DistinteBrowser(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckConstructorParameters(ambientDbContextLocator);

            _ambientDbContextLocator = ambientDbContextLocator;

        }

        public void BrowseDistinte(DistintaFilter filter)
        {
            var distinteDataService = DistinteDataServiceFactory.GetInstance(_ambientDbContextLocator);

            var listDistinte = distinteDataService.BrowserDistinta(filter);
        }

        readonly IAmbientDbContextLocator _ambientDbContextLocator;

        static void CheckConstructorParameters(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
            }
        }
    }
}
