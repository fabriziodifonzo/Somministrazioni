using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Somministrazioni.Web.Models.Distinte
{
    public class DistinteModel : ModelBase
    {
        public DistinteModel() 
        {
        }

        public DistinteModel(string message, bool hasInfoPanel) : base(hasInfoPanel)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public string Field1
        {
            get; set;
        }
        public string Field2
        {
            get; set;
        }
        public string Message { get; set; }
    }
}