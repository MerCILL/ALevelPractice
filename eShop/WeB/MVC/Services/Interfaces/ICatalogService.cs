using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;

namespace MVC.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogItemsAsync(PaginatedItemsRequest request);
        Task<IEnumerable<SelectListItem>> GetBrandsAsync();
        Task<IEnumerable<SelectListItem>> GetTypesAsync();

    }
}
