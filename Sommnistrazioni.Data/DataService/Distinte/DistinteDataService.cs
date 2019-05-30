using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using Somministrazioni.Common.Filters;
using Sommnistrazioni.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.DataService.Distinte
{
    public class DistinteDataService : IDistinteDataService
    {
        public DistinteDataService(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckConstructorParameters(ambientDbContextLocator);

            _ambientDbContextLocator = ambientDbContextLocator;
        }

        public IList<DistintaBrowsed> BrowserDistinta(DistintaFilter filter)
        {
            CheckBrowserDistintaParameters(filter);

            return new List<DistintaBrowsed>();
        }

        public int CountDistinte(DistintaFilter filter)
        {
            CheckCountDistinteParameters(filter);

            return BrowserDistinta(filter).Count;
        }

        readonly IAmbientDbContextLocator _ambientDbContextLocator;

        static void CheckConstructorParameters(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(ambientDbContextLocator));
            }
        }

        static void CheckBrowserDistintaParameters(DistintaFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filter));
            }
        }

        static void CheckCountDistinteParameters(DistintaFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(filter));
            }
        }
    }
}
