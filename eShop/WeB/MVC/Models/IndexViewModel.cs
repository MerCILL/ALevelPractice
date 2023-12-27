using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<CatalogItem> CatalogItems { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
