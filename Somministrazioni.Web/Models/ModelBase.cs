﻿using System;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = string.Empty;
                }

                _sortBy = value;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = string.Empty;
                }
                _sortDirection = value;
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