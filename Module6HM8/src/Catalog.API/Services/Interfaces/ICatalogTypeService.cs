namespace Catalog.API.Services.Interfaces;

    public interface ICatalogTypeService
    {
        Task<IEnumerable<CatalogType>> Get();
    }

