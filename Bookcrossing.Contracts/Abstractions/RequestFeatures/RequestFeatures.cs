using Bookcrossing.Contracts.Enumeration;

namespace Bookcrossing.Contracts.Abstractions.RequestFeatures
{
    public abstract class RequestFeatures
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;
        public Order OrderBy { get; set; } = Order.Asc;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
