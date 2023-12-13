using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly List<Product> _products = new()
        {
            new Product(1, "Product1", 100),
            new Product(2, "Product2", 150),
            new Product(3, "Product3", 200),
            new Product(4, "Product4", 250),
            new Product(5, "Product5", 500),
            new Product(6, "Product6", 1000),
        };

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public Product GetProductById(int id)
        {
            return _products[id - 1];
        }

        [HttpGet("{id}/title", Name = "GetProductByIdTitle")]
        public Product GetProductByIdTitle(int id, [FromQuery] string title) 
        {
            return _products.FirstOrDefault(x => x.Id == id && x.Title == title);
        }
    }
}
