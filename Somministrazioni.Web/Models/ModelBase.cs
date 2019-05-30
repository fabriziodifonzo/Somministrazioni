using EasyMaticaSrl.Utilities.Helpers;
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
            _sortBy = string.Empty;
            _sortDirection = string.Empty;
        }

        public bool HasPanelInfo
        {
            get 
            {
                return _hasPanelInfo;
            }
        }

        public string SortBy
        {
            get
            {
                return _sortBy;
            }
            set
            {
                _sortBy = StringHelper.EmptyIfNull(value);
            }
        }

        public string SortDirection
        {
            get
            {
                return _sortDirection;
            }
            set
            {
                _sortDirection = StringHelper.EmptyIfNull(value);
            }
        }

        public int CurrentPageIndex
        {
            get;set;
        }


        public int PageSize
        {
            get; set;
        }

        string _sortBy;
        string _sortDirection;
        readonly protected bool _hasPanelInfo;
    }
}