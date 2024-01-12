namespace Catalog.API.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<IEnumerable<CatalogType>> Get();
}

