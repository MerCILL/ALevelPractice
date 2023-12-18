using Catalog.Host.Data;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        //Task<int?> Add(AddCatalogItemRequest addCatalogItem);
        Task<PaginatedItems<CatalogTypeDto>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
    }
}
