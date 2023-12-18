using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogBrandRepository> _logger;

        public CatalogBrandRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogBrandRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<PaginatedItems<CatalogBrand>> GetByPageAsyncHttpGet(int pageIndex, int pageSize)
        {
            var totalItems = await _dbContext.CatalogBrands.LongCountAsync();

            var brands = await _dbContext.CatalogBrands
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<CatalogBrand>
            {
                TotalCount = totalItems,
                Data = brands
            };
        }

        public async Task<PaginatedItems<CatalogBrand>> GetBrandsByPageAsync(int pageIndex, int pageSize)
        {
            var totalItems = await _dbContext.CatalogBrands.LongCountAsync();

            var brands = await _dbContext.CatalogBrands
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageIndex - 1)) 
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<CatalogBrand>
            {
                TotalCount = totalItems,
                Data = brands
            };
        }

        public async Task<CatalogBrand> GetBrandByIdAsync(int id)
        {
            return await _dbContext.CatalogBrands.FindAsync(id);
        }


    }
}
