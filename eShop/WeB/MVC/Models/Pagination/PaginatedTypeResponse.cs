namespace MVC.Models.Pagination
{
    public class PaginatedTypeResponse
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<CatalogType> Data { get; set; }
    }
}
