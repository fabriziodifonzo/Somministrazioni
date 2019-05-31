using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCWeb.Business.Components.Browsers.Models
{
    public sealed class PagedResultInfoBase
    {
        public int PageNumber
        { 
            get
            {
                return _pageNumber;
            }
        }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
        }

        public int MatchingRecordsCount
        {
            get
            {
                return _matchingRecordsCount;

            }
        }

        public static PagedResultInfoBase Of(int pageNumber, int pageSize, int matchingRecordsCount)
        {            
            return new PagedResultInfoBase(pageNumber, pageSize, matchingRecordsCount);
        }

        PagedResultInfoBase(int pageNumber, int pageSize, int matchingRecordsCount)
        {           
            _pageNumber = pageNumber;
            _pageSize = pageSize;
            _matchingRecordsCount = matchingRecordsCount;
        }

        readonly int _pageNumber;
        readonly int _pageSize;
        readonly int _matchingRecordsCount;
    }
}
