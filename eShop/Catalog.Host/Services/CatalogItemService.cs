using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Models.Requests.AddRequests;
using Catalog.Host.Models.Requests.DeleteRequests;
using Catalog.Host.Models.Requests.UpdateRequests;
using Catalog.Host.Models.Responses.UpdateResponses;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly IMapper _mapper;

        public CatalogItemService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogItemRepository catalogItemRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogItemRepository = catalogItemRepository;
            _mapper = mapper;
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

        public async Task<UpdateCatalogItemResponse<int>> Update(UpdateCatalogItemRequest updateCatalogItem)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var item = await _catalogItemRepository.Update(updateCatalogItem);
                return new UpdateCatalogItemResponse<int>
                {                  
                    Item = _mapper.Map<CatalogGetItemDto>(item)
                };
            });
        }

        public Task Delete(DeleteCatalogItemRequest deleteCatalogItem)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.Delete(deleteCatalogItem));
        }


    }
}
