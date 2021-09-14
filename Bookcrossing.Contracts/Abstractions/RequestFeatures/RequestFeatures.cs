using Bookcrossing.Contracts.Enumeration;

namespace Bookcrossing.Contracts.Abstractions.RequestFeatures
{
    public abstract class RequestFeatures
    {
        private const int MaxPageSize = 100;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public Ordery OrderyBy { get; set; } = Ordery.Asc;
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
