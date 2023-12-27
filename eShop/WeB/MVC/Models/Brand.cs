namespace MVC.Models
{
    public class Brand
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<CatalogBrand> Data { get; set; }
    }
}
