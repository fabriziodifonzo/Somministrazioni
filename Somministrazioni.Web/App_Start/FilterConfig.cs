﻿using Somministrazioni.Web.Filter;
using System.Web;
using System.Web.Mvc;

namespace Somministrazioni.Web
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        { 
            filters.Add(new HandleErrorAttribute());
        }
    }
}
