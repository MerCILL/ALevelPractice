namespace Catalog.API.Repositories;

public class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly CatalogDbContext _dbContext;
    private readonly ILogger<CatalogTypeRepository> _logger;

    public CatalogTypeRepository(
        CatalogDbContext dbContext,
        ILogger<CatalogTypeRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IEnumerable<CatalogType>> Get()
    {
        return await _dbContext.CatalogTypes.ToListAsync();
    }

}

