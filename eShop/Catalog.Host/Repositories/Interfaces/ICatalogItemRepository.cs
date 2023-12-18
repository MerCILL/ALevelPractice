using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Models.Requests.AddRequests;
using Catalog.Host.Models.Requests.DeleteRequests;
using Catalog.Host.Models.Requests.UpdateRequests;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogItemRepository
    {
        Task<PaginatedItems<CatalogItem>> GetItemsByPageAsync(int pageIndex, int pageSize);
        Task<CatalogItem> GetItemByIdAsync(int id);
        Task<IEnumerable<CatalogItem>> GetItemsByBrandAsync(int brandId);
        Task<IEnumerable<CatalogItem>> GetItemsByTypeAsync(int typeId);

        Task<PaginatedItems<CatalogItem>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
        Task<int?> Add(AddCatalogItemRequest itemToAdd);
        Task<CatalogItem> Update(UpdateCatalogItemRequest itemToUpdate);
        Task Delete(DeleteCatalogItemRequest itemToDelete);
    }
}
