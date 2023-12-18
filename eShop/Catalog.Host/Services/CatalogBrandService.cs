using Catalog.Host.Data;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
        }

        public async Task<PaginatedItems<CatalogBrandDto>> GetByPageAsyncHttpGet(int pageIndex, int pageSize)
        {
            var result = await _catalogBrandRepository.GetByPageAsyncHttpGet(pageIndex, pageSize);

            var data = result.Data.Select(item => new CatalogBrandDto
            {
                Id = item.Id,
                Brand = item.Brand
            });

            return new PaginatedItems<CatalogBrandDto>
            {
                TotalCount = result.TotalCount,
                Data = data
            };
        }
    }
}
