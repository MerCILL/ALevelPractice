namespace Catalog.Host.Models.Responses
{
    public class AddCatalogItemResponse<T>
    {
        public T Id { get; set; } = default(T)!;
    }
}
