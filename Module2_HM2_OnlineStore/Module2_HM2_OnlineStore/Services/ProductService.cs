using Module2_HM2_OnlineStore.Entities;
using Module2_HM2_OnlineStore.Models;
using Module2_HM2_OnlineStore.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Services
{
    internal class ProductService
    {
        private readonly ProductRepository _productRepository;

        private List<Product> _products;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public string AddProduct(string title, decimal price, int quantity)
        {
            string SKU = _productRepository.AddProduct(title, price, quantity);
            return SKU;
        }

        public void ShowAllProducts()
        {
            foreach (var product in _productRepository.GetAllProducts())
            {
                int? quantity = _productRepository.GetProductQuantity(product.SKU);
                Console.WriteLine($"Title: {product.Title}, Price: {product.Price}, SKU: {product.SKU}, Quantity: {quantity}");
            }
        }

        public List<Product> GetAllProducts()
        {
            _products = new List<Product>();
            foreach (var item in _productRepository.GetAllProducts())
            {
                _products.Add(new Product()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Price = item.Price,
                    SKU = item.SKU,
                });
            }
            return _products;
        }

        public bool CheckExistingProduct(string SKU)
        {
            return (_productRepository.GetAllProducts().Any(x => x.SKU == SKU));
        }

        public int? GetProductQuantity(string SKU)
        {
            return _productRepository.GetProductQuantity(SKU);
        }

        public Product GetProductToAddInOrder(string SKU, int quantity)
        {
            //if (quantity <= 10 && quantity >= 1 && SKU == _productRepository.GetProductSKU(SKU) && quantity <= _productRepository.GetProductQuantity(SKU))
            //{
            //    var product = _productRepository.GetProductBySKU(SKU);                        
            //}
            if(SKU == _productRepository.GetProductSKU(SKU) && quantity <= _productRepository.GetProductQuantity(SKU))
            {
                var product = _productRepository.GetProductBySKU(SKU);
                return new Product()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Price = product.Price,
                    SKU = product.SKU,
                };
            }
            return null;
        }

        public void DeleteProducts(List<Product> products)
        {
            List<ProductEntity> entities = new List<ProductEntity>();
            foreach (var product in products) 
            {
                entities.Add(new ProductEntity
                {
                    Id = product.Id,
                    Title = product.Title,
                    Price = product.Price,
                    SKU = product.SKU,
                });
            }
            _productRepository.DeleteProducts(entities);
        }

    }
}
