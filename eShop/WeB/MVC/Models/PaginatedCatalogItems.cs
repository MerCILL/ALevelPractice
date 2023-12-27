namespace MVC.Models
{
    public class PaginatedCatalogItems
    {
        public int PageIndex { get; init; }
        public int PageSize { get; init; }
        public int Count { get; init; }
        public List<CatalogItem> Data { get; init; }
    }
}
