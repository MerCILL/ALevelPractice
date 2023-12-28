using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models.Pagination;
using MVC.Models.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<SelectListItem>> GetBrandsAsync();
        Task<IEnumerable<SelectListItem>> GetTypesAsync();
        Task<PaginatedItemsResponse<CatalogItemViewModel>> GetCatalogItemsAsync(PaginatedItemsRequest request);

    }
}
