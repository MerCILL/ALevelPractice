namespace Catalog.API.Services
{
    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly ILogger<CatalogTypeService> _logger;

        public CatalogTypeService(
            ICatalogTypeRepository catalogTypeRepository,
            ILogger<CatalogTypeService> logger)
        {
            _catalogTypeRepository = catalogTypeRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<CatalogType>> Get()
        {
            return await _catalogTypeRepository.Get();
        }

    }
}
