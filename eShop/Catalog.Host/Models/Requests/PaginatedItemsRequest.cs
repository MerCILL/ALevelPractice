namespace Catalog.Host.Models.Requests
{
    public class PaginatedItemsRequest
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

    }
}
