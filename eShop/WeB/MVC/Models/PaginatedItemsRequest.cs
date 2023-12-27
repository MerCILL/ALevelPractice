namespace MVC.Models
{
    public class PaginatedItemsRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
    }
}
