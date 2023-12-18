using Catalog.Host.Data;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;

        public CatalogItemService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogItemRepository catalogItemRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public async Task<PaginatedItems<CatalogGetItemDto>> GetByPageAsyncHttpGet(int pageIndex, int pageSize)
        {
            var result = await _catalogItemRepository.GetByPageAsyncHttpGet(pageIndex, pageSize);

            var data = result.Data.Select(item => new CatalogGetItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                PictureUrl = item.PictureFileName,
                BrandName = item.CatalogBrand.Brand,
                TypeName = item.CatalogType.Type
            });

            return new PaginatedItems<CatalogGetItemDto>
            {
                TotalCount = result.TotalCount,
                Data = data
            };
        }

        public Task<int?> Add(AddCatalogItemRequest addCatalogItem)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.Add(addCatalogItem));
        }

    }
}
