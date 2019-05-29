using EntityFramework.DbContextScope.Interfaces;
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
            _ambientDbContextLocator = ambientDbContextLocator;
        }

        readonly IAmbientDbContextLocator _ambientDbContextLocator;
    }
}
