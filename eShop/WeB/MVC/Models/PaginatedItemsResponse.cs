namespace MVC.Models
{
    public class PaginatedItemsResponse<T>
    {
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<T> Data { get; set; }
    }
}
