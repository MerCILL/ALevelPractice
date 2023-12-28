namespace MVC.Models
{
    public class CatalogResponse
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IEnumerable<CatalogItemViewModel> Data { get; set; }
    }
}
