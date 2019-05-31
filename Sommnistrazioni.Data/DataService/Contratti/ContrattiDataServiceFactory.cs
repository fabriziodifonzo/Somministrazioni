using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using Sommnistrazioni.Data.DataService.Distinte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService.Contratti
{
    public static class ContrattiDataServiceFactory
    {
        public static IContrattiDataService GetInstance(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckGetInstanceParamets(ambientDbContextLocator);

            return new ContrattiDataService(ambientDbContextLocator);
        }

        public static void CheckGetInstanceParamets(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
            }
        }
    }
}
