using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogItemRepository> _logger;

        public CatalogItemRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogItemRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }


        public async Task<PaginatedItems<CatalogItem>> GetByPageAsyncHttpGet(int pageIndex, int pageSize)
        {
            var totalItems = await _dbContext.CatalogItems.LongCountAsync();

            var catalogItems = await _dbContext.CatalogItems
                .Include(item => item.CatalogBrand)
                .Include(item => item.CatalogType)
                .OrderBy(x => x.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();


            return new PaginatedItems<CatalogItem>
            {
                TotalCount = totalItems,
                Data = catalogItems
            };
        }

        public async Task<PaginatedItems<CatalogItem>> GetItemsByPageAsync(int pageIndex, int pageSize)
        {
            var totalItems = await _dbContext.CatalogItems.LongCountAsync();

            var catalogItems = await _dbContext.CatalogItems
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<CatalogItem>
            {
                TotalCount = totalItems,
                Data = catalogItems
            };
        }

        public async Task<CatalogItem> GetItemByIdAsync(int id)
        {
            return await _dbContext.CatalogItems.FindAsync(id);
        }

        public async Task<IEnumerable<CatalogItem>> GetItemsByBrandAsync(int brandId)
        {
            return await _dbContext.CatalogItems
               .Include(item => item.CatalogBrand)
               .Include(item => item.CatalogType)
               .Where(item => item.CatalogBrandId == brandId)
               .ToListAsync();
        }

        public async Task<IEnumerable<CatalogItem>> GetItemsByTypeAsync(int typeId)
        {
            return await _dbContext.CatalogItems
               .Include(item => item.CatalogBrand)
               .Include(item => item.CatalogType)
               .Where(item => item.CatalogTypeId == typeId)
               .ToListAsync();
        }

        public async Task<int?> Add(AddCatalogItemRequest itemToAdd)
        {
            var item = await _dbContext.AddAsync(new CatalogItem
            {
                CatalogBrandId = itemToAdd.CatalogBrandId,
                CatalogTypeId = itemToAdd.CatalogTypeId,
                Description = itemToAdd.Description,
                Name = itemToAdd.Name,
                PictureFileName = itemToAdd.PictureFileName,
                Price = itemToAdd.Price
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

      

    }
}
