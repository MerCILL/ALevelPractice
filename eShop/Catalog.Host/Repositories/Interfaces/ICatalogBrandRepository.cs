using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<PaginatedItems<CatalogBrand>> GetBrandsByPageAsync(int pageIndex, int pageSize);
        Task<CatalogBrand> GetBrandByIdAsync(int id);

        Task<PaginatedItems<CatalogBrand>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
    }
}
