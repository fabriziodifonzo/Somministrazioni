using Sommnistrazioni.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Somministrazioni.Common.Filters;

namespace Sommnistrazioni.Data.DataService.Distinte
{
    public interface IDistinteDataService
    {
        IList<DistintaBrowsed> BrowserDistinta(DistintaFilter filter);
    }
}
