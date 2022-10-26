

namespace BancoSolidario.ExtendApplication.Features.Shared.Queries
{
    public class PaginationBaseQuery
    {
       
        public string? Sort { get; set; }
        public string? SearchQuery { get; set; }

        public int PageIndex { get; set; } = 1;
        private int _pageSize = 3;

        private int MaxPageSize = 50;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public bool IsPaging { get; set; }

        public string? Token { get; set; }

    }
}
