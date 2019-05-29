using EntityFramework.DbContextScope.Interfaces;
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
            _ambientDbContextLocator = ambientDbContextLocator;
        }

        readonly IAmbientDbContextLocator _ambientDbContextLocator;
    }
}
