using Somministrazioni.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somministrazioni.Common.Filters
{
    public abstract class FilterBase
    {
        public string SortBy
        {
            get
            {
                return _sortBy;
            }
        }

        public string SortDirection
        {
            get
            {
                return _sortDirection;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return _currentPageIndex;
            }
        }


        public int PageSize
        {
            get 
            {
                return _pageSize;
            }
        }

        protected FilterBase(String sortBy, string sortDirection, int currentPageIndex, int pageSize)
        {
            CheckConstructorParameter(sortBy, sortDirection);

            _sortBy = sortBy;
            _sortDirection = sortDirection;
            _currentPageIndex = currentPageIndex;
            _pageSize = pageSize;

        }

        readonly string _sortBy;
        readonly string _sortDirection;
        readonly int _currentPageIndex;
        readonly int _pageSize;

        static void CheckConstructorParameter(String sortBy, string sortDirection)
        {
            if (sortBy == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(sortBy));
            }

            if (sortDirection == null)
            {
                throw new ArgumentException(GenericConstants.ERRMSG_NULLARGUMENT + GenericConstants.CHR_SPACE + nameof(sortDirection));
            }
        }
    }
}
