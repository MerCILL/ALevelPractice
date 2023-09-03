using Module2_HM2_OnlineStore.Entities;
using Module2_HM2_OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Repositories
{
    internal class ProductRepository
    {
        private readonly Dictionary<string, ProductEntity> _products = new Dictionary<string, ProductEntity>();
        private readonly Dictionary<string, int> _productQuantities = new Dictionary<string, int>();

        public string AddProduct(string title, decimal price, int quantity)
        {
            //string SKU = String.Concat(title.Remove(5), price);
            string SKU = String.Concat(title.Length > 5 ? title.Substring(0, 5) : title, price);

            if (!_products.ContainsKey(SKU))
            {
                var product = new ProductEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    SKU = SKU,
                    Title = title,
                    Price = price,
                };
                _products[SKU] = product;
                _productQuantities[SKU] = 0;
            }

            _productQuantities[SKU] += quantity;

            return SKU;
        }
 
        public ProductEntity? GetProductBySKU(string SKU)
        {
            return _products.ContainsKey(SKU) ? _products[SKU] : null;
        }

        public string GetProductSKU(string SKU)
        {
            return GetProductBySKU(SKU).SKU;
        }

        public List<ProductEntity> GetAllProducts()
        {
            return _products.Values.ToList();
        }

        public int? GetProductQuantity(string SKU)
        {
            return _productQuantities.ContainsKey(SKU) ? _productQuantities[SKU] : null;
        }

        public void DeleteProducts(List<ProductEntity> productEntities)
        {
            foreach (var productEntity in productEntities)
            {
                if (_products.ContainsKey(productEntity.SKU))
                    _productQuantities[productEntity.SKU] -= 1; // Уменьшаем количество на 1
            }
        }
 
    }
}
