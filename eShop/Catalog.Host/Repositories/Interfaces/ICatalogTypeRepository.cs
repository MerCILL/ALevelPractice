using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<PaginatedItems<CatalogType>> GetTypesByPageAsync(int pageIndex, int pageSize);
        Task<CatalogType> GetTypeByIdAsync(int id);

        Task<PaginatedItems<CatalogType>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);

    }
}
