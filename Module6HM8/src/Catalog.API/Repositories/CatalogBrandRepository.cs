namespace Catalog.API.Repositories;
public class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly CatalogDbContext _dbContext;
    private readonly ILogger<CatalogBrandRepository> _logger;

    public CatalogBrandRepository(
        CatalogDbContext dbContext,
        ILogger<CatalogBrandRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    public async Task<IEnumerable<CatalogBrand>> Get()
    {
        return await _dbContext.CatalogBrands.AsNoTracking().OrderBy(brand => brand.Id).ToListAsync();
    }

    public async Task<int> Add(CatalogBrand CatalogBrand)
    {
        _dbContext.CatalogBrands.Add(CatalogBrand);

        await _dbContext.SaveChangesAsync();

        return CatalogBrand.Id;
    }

    public async Task Update(CatalogBrand CatalogBrand)
    {
        var existingCatalogBrand = await _dbContext.CatalogBrands.FirstOrDefaultAsync(brand => brand.Id == CatalogBrand.Id);

        existingCatalogBrand.Brand = CatalogBrand.Brand;

        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var existingCatalogBrand = await _dbContext.CatalogBrands.FirstOrDefaultAsync(brand => brand.Id == id);

        _dbContext.CatalogBrands.Remove(existingCatalogBrand);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<CatalogBrand> GetByName(string brandName)
    {
        return await _dbContext.CatalogBrands.FirstOrDefaultAsync(brand => brand.Brand == brandName);
    }

    public async Task<CatalogBrand> GetById(int id)
    {
        return await _dbContext.CatalogBrands.FirstOrDefaultAsync(brand => brand.Id == id);
    }
}
