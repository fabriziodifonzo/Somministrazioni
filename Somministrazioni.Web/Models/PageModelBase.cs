using EasyMaticaSrl.Utilities.Helpers;
using Somministrazioni.Common.Constants;
using Somministrazioni.Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Somministrazioni.Web.Models
{
    public abstract class PageModelBase
    {
        protected PageModelBase(int errorCode, string errorMsg)
        {
            _initBase();
            _errorCode = errorCode;
            _errorMsg = errorMsg;
        }

        protected PageModelBase()
        {
            _initBase();
            _errorCode = GenericConstants.ERRCODE_OK;
            _errorMsg = string.Empty;
        }

        public int ErrorCode
        {
            get 
            {
                return _errorCode;
            }
        }

        public string ErrorMsg
        {
            get
            {
                return _errorMsg;
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

        void _initBase()
        {
            _sortBy = string.Empty;
            _sortDirection = string.Empty;
            PageSize = WebConstants.PAGESISZE_DEFAULT;
            CurrentPageNumb = WebConstants.PAGENUMB_DEFAULT;
        }

        string _sortBy;
        string _sortDirection;
        readonly protected int _errorCode;
        readonly protected string _errorMsg;
    }
}