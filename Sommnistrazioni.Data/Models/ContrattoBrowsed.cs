using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommnistrazioni.Data.Models
{
    public class ContrattoBrowsed
    {
        public static ContrattoBrowsed Of(string codice)
        {
            return new ContrattoBrowsed(codice);
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
