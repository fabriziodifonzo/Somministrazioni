using Somministrazioni.Common.Constants;
using Somministrazioni.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.Models
{
    public sealed class DistintaBrowsed
    {
        public static DistintaBrowsed Of(string codice, StatoDistinta statoDistinta)
        {
            return new DistintaBrowsed(codice, statoDistinta);
        }

        public string Codice
        {
            get
            {
                return _codice;
            }
        }

        public StatoDistinta StatoDistinta
        {
            get
            {
                return _statoDistinta;
            }
        }

        public override string ToString()
        {
            var toStringBuilder = new StringBuilder();

            toStringBuilder.Append("[ ");
            toStringBuilder.Append("Codice: ");
            toStringBuilder.Append(" = ");
            toStringBuilder.Append(_codice);
            toStringBuilder.Append(",");
            toStringBuilder.Append("Stato: ");
            toStringBuilder.Append(" = ");
            toStringBuilder.Append(_statoDistinta);
            toStringBuilder.Append(",");
            toStringBuilder.Append(" ]");

            return toStringBuilder.ToString();
        }

        DistintaBrowsed(string codice, StatoDistinta statoDistinta)
        {
            _codice = codice;
            _statoDistinta = statoDistinta;
        }

        readonly string _codice;
        readonly StatoDistinta _statoDistinta;
    }
}
