namespace Catalog.API.Data;

public class CatalogDbContextSeed
{
    private readonly ILogger<CatalogDbContextSeed> _logger;
    public CatalogDbContextSeed(ILogger<CatalogDbContextSeed> logger)
    {
        _logger = logger;
    }
    public async Task SeedAsync(CatalogDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!context.CatalogItems.Any()) 
        {
            context.CatalogBrands.AddRange(
                new CatalogBrand { Id = 1, Brand = "Brand 1" },
                new CatalogBrand { Id = 2, Brand = "Brand 2" }
            );
            _logger.LogInformation($"Seeded catalog with {context.CatalogBrands.Count()} brands");

            context.CatalogTypes.AddRange(
                new CatalogType { Id = 1, Type = "Type 1" },
                new CatalogType { Id = 2, Type = "Type 2" }
            );
            _logger.LogInformation($"Seeded catalog with {context.CatalogTypes.Count()} types");

            context.CatalogItems.AddRange(
              new CatalogItem { Id = 1, Name = "Item 1", Description = "Description 1", Price = 100, PictureUri = "1.png", CatalogTypeId = 1, CatalogBrandId = 1, AvailableStock = 10 },
              new CatalogItem { Id = 2, Name = "Item 2", Description = "Description 2", Price = 200, PictureUri = "2.png", CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 15 },
              new CatalogItem { Id = 3, Name = "Item 3", Description = "Description 3", Price = 300, PictureUri = "3.png", CatalogTypeId = 1, CatalogBrandId = 1, AvailableStock = 20 },
              new CatalogItem { Id = 4, Name = "Item 4", Description = "Description 4", Price = 400, PictureUri = "4.png", CatalogTypeId = 1, CatalogBrandId = 2, AvailableStock = 25 },
              new CatalogItem { Id = 5, Name = "Item 5", Description = "Description 5", Price = 500, PictureUri = "5.png", CatalogTypeId = 2, CatalogBrandId = 2, AvailableStock = 5 }
          );
            _logger.LogInformation($"Seeded catalog with {context.CatalogItems.Count()} items");

            await context.SaveChangesAsync();
        }

        else
        {
            _logger.LogInformation("CatalogContextSeed data already exists");
        }

    }
}

