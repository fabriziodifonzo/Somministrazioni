using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.BusinessFacade
{
    public static class BusinessFacadeFactory
    {
        public static IBusinessFacade GetInstance()
        {
            return new BusinessFacade();
        }
    }
}
