﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Business.Components.Browsers.Models.Contratto
{
    public class ContrattoBrowsed
    {
        public static ContrattoBrowsed Of(string codice)
        {
            return new ContrattoBrowsed(codice);
        }

        public static ContrattoBrowsed From(Sommnistrazioni.Data.Models.ContrattoBrowsed contrattoBrowsed)
        {
            return ContrattoBrowsed.Of(contrattoBrowsed.Codice);
        }

        public string Codice
        {
            get
            {
                return _codice;
            }
        }

        ContrattoBrowsed(string codice)
        {
            _codice = codice;
        }

        readonly string _codice;
    }
}
