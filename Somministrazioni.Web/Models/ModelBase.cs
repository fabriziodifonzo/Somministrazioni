using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Somministrazioni.Web.Models
{
    public abstract class ModelBase
    {
        protected ModelBase(bool hasPanelInfo)
        {
            _hasPanelInfo = hasPanelInfo;
        }

        protected ModelBase()
        {         
        }

        public bool HasPanelInfo
        {
            get 
            {
                return _hasPanelInfo;
            }
        }

        readonly protected bool _hasPanelInfo;
    }
}