using EasyMaticaSrl.Utilities.Helpers;
using Somministrazioni.WebApi.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Somministrazioni.WebApi.Models.Distinte
{
    public abstract class RestModelBase
    {
        protected RestModelBase(bool hasPanelInfo)
        {
            _hasPanelInfo = hasPanelInfo;
        }

        protected RestModelBase()
        {
            _sortBy = string.Empty;
            _sortDirection = string.Empty;
            PageSize = RestConstants.PAGESISZE_DEFAULT;
            CurrentPageNumb = RestConstants.PAGENUMB_DEFAULT;
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

        public int CurrentPageNumb
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