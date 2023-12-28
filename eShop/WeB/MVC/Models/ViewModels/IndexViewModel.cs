using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models.Pagination;

namespace MVC.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<CatalogItem> CatalogItems { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
