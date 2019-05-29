using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Common.Enums
{
    public enum StatoDistinta
    {
        [Description("Pianificata")]
        Pianificata,
        [Description("Da Validare")]
        DaValidare,
        [Description("Sospesa")]
        Sospesa,
        [Description("Conforme")]
        Conforme,
        [Description("Non Conforme")]
        NonConforme,
        [Description("Annullata")]
        Annullata
    }
}
