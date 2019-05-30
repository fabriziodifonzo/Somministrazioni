﻿using Somministrazioni.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.Models
{
    public sealed class DistintaBrowsed
    {
        public static DistintaBrowsed Of(StatoDistinta statoDistinta)
        {
            return new DistintaBrowsed(statoDistinta);
        }

        public StatoDistinta StatoDistinta
        {
            get
            {
                return _statoDistinta;
            }
        }

        DistintaBrowsed(StatoDistinta statoDistinta)
        {
            _statoDistinta = statoDistinta;
        }

        readonly StatoDistinta _statoDistinta;
    }
}