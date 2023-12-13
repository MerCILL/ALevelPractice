namespace Catalog.Host
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }

        public Product(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

    }
}
