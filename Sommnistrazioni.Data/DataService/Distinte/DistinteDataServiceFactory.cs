using EntityFramework.DbContextScope.Interfaces;
using log4net;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService.Distinte
{
    public static class DistinteDataServiceFactory
    {
        public static IDistinteDataService GetInstance(ILog log, IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckGetInstanceParamets(ambientDbContextLocator);

            return new DistinteDataService(log, ambientDbContextLocator);
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
