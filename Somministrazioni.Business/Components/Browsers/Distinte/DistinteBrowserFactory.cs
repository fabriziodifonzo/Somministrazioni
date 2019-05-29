using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Browsers.Distinte
{
    public static class DistinteBrowserFactory
    {
        public static IDistinteBrowser GetInstance(IAmbientDbContextLocator ambientDbContextLocator)
        {
            CheckGetInstanceParamets(ambientDbContextLocator);

            return new DistinteBrowser(ambientDbContextLocator);
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
