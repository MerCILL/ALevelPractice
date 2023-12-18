using Catalog.Host.Data;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;

        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogTypeRepository catalogTypeRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogTypeRepository = catalogTypeRepository;
        }

        async Task<PaginatedItems<CatalogTypeDto>> ICatalogTypeService.GetByPageAsyncHttpGet(int pageIndex, int pageSize)
        {
        var result = await _catalogTypeRepository.GetByPageAsyncHttpGet(pageIndex, pageSize);

            var data = result.Data.Select(item => new CatalogTypeDto
            {
                Id = item.Id,
                Type = item.Type
            });

            return new PaginatedItems<CatalogTypeDto>
            {
                TotalCount = result.TotalCount,
                Data = data
            };
        }

    }
}
