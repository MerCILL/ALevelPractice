using Module2_HM2_OnlineStore.Entities;
using Module2_HM2_OnlineStore.Models;
using Module2_HM2_OnlineStore.Repositories;
using Module2_HM2_OnlineStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore
{
    internal class Shopping
    {
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;
        private readonly NotifyCustomer _notifyCustomer;

        public Shopping(CustomerService customerService, ProductService productService, OrderService orderService, NotifyCustomer notifyCustomer)
        {
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            _notifyCustomer = notifyCustomer;
        }

        public void AddCustomer(string login, string firstName, string lastName, string email)
        {
            _customerService.AddCustomer(login, firstName, lastName, email);
            Console.WriteLine($"Customer {login} was added");
        }

        public void GetCustomer(string login)
        {
            _customerService.GetCustomer(login);
        }

        public void GetCustomers()
        {
            _customerService.GetCustomers();
        }

        public void ShowCustomersInfo()
        {
            _customerService.ShowCustomersInfo();
        }
        public void ShowCustomer(string login)
        {
            _customerService.ShowCustomerInfo(login);
        }

        public void AddProduct(string title, decimal price, int quantity)
        {
            var SKU = _productService.AddProduct(title, price, quantity);
            Console.WriteLine($"Product {title} {SKU} was added in quantity {quantity}");
        }

        public void ShowAllProducts()
        {
            _productService.ShowAllProducts();
        }

        public bool SelectedCustomer(string login, string email)
        {
            if (_customerService.GetCustomers().Any(x => x.Login == login && x.Email == email))
                return true;
            return false;
        }

        public void AddProductsInShoppingCart(string login, string email)
        {
            if (!SelectedCustomer(login, email))
            {
                Console.WriteLine("Customer selection error");
                return;
            }

            Product productToAdd;
            int shoppingCartCapacity = 10;


            for (int i = 1; i <= 10;)
            {
                Console.Write("SKU: ");
                string SKU = Console.ReadLine();
                if (SKU == "exit" || SKU == "") break;
                if (!_productService.CheckExistingProduct(SKU))
                    continue;

                Console.Write("Quantity: ");
                int productToAddQuantity = Convert.ToInt32(Console.ReadLine());
                if (productToAddQuantity <= 0 || productToAddQuantity > 10)
                    continue;

                if (productToAddQuantity > _productService.GetProductQuantity(SKU))
                {
                    Console.WriteLine("Not enough product");
                    continue;
                }

                if(productToAddQuantity > shoppingCartCapacity)
                {
                    Console.WriteLine("Not enough place in cart");
                    continue;
                }

                productToAdd = _productService.GetProductToAddInOrder(SKU, productToAddQuantity);

                while (productToAddQuantity != 0 && shoppingCartCapacity != 0)
                {

                    _customerService.GetCustomer(login).ShoppingCart.Products.Add(productToAdd);
                    i++;
                    productToAddQuantity--;
                    shoppingCartCapacity--;
                    //Console.WriteLine($"i: {i} product to add {productToAddQuantity} capacity {shoppingCartCapacity}");
                }
            }
        }
        
        public void ShowCart(string login)
        {
           _customerService.ShowCart(login);
        }

        public void ConfirmOrder(string login)
        {
            if (_customerService.checkCustomerIsNull(login)) return;
            if (_customerService.checkCartIsNull(login))
            {
                Console.WriteLine("Cart is empty");
                return;
            }
            if (_customerService.checkCartIsEmpty(login)) return;

            Console.Write("Address: ");
            string orderAddress = Console.ReadLine();

            if (orderAddress == null) return;

            Console.WriteLine("Confirm: ");
            string confirm = Console.ReadLine();

            if(confirm.ToLower() != "confirm")
            {
                Console.WriteLine("Confirmation was rejected");
                return;
            }

            int id = _orderService.AddOrder(DateTime.UtcNow, orderAddress, _customerService.GetCustomer(login).ShoppingCart.Products);

            OrderEntity orderEntity;
            Order order = _orderService.GetOrder(id);
            orderEntity = new OrderEntity
            {
                Id = order.Id,
                OrderAddress = order.OrderAddress,
                OrderDate = order.OrderDate,
                productEntities = order.productEntities
            };

            _customerService.GetCustomer(login).OrderList.Add(orderEntity);
            _notifyCustomer.SuccesfulOrderCreationMessage(login, id);

            _productService.DeleteProducts(_customerService.GetCustomer(login).ShoppingCart.Products);
            _customerService.GetCustomer(login).ShoppingCart.Products.Clear();

        }

        public void ShowOrdersProducts()
        {
            var orders = _orderService.GetOrders();
            List<ProductEntity> productEntities = new List<ProductEntity>();
            List<Product> products = new List<Product>();
            decimal totalAmount = 0;

            foreach (var order in orders)
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine($"Order #{order.Id}: Creation date: {order.OrderDate} Address: {order.OrderAddress}");

                var groupedProducts = order.productEntities.GroupBy(p => p.SKU);

                foreach (var group in groupedProducts)
                {
                    var product = group.First();
                    int quantity = group.Count();
                    totalAmount += product.Price * quantity;
                    Console.WriteLine($"Title: {product.Title}, Price: {product.Price}, SKU: {product.SKU}, Quantity: {quantity}");
                }
                Console.WriteLine($"Total Price: {totalAmount}");
                totalAmount = 0;
            }        
        }

        public void ShowOrders()
        {
            foreach (var order in _orderService.GetOrders())
            {
                Console.WriteLine($"Order #{order.Id}: Creation date: {order.OrderDate} Address: {order.OrderAddress}");
            }
        }

        public void ShowOrdersByCustomer(string login)
        {
            decimal totalAmount = 0;
            foreach (var order in _customerService.GetCustomer(login).OrderList)
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine($"Order #{order.Id}: Creation date: {order.OrderDate} Address: {order.OrderAddress}");

                var groupedProducts = order.productEntities.GroupBy(p => p.SKU);

                foreach (var group in groupedProducts)
                {
                    var product = group.First();
                    int quantity = group.Count();
                    totalAmount += product.Price * quantity;
                    Console.WriteLine($"Title: {product.Title}, Price: {product.Price}, SKU: {product.SKU}, Quantity: {quantity}");
                }
                Console.WriteLine($"Total Price: {totalAmount}");
                totalAmount = 0;
            }
        }

        public void ShowOrderById(int id)
        {
            var order = _orderService.GetOrder(id);

            if (order == null) return;

            var groupedProducts = order.productEntities.GroupBy(p => p.SKU);
            decimal totalAmount = 0;

            Console.WriteLine($"Order #{order.Id}: Creation date: {order.OrderDate} Address: {order.OrderAddress}");

            foreach (var group in groupedProducts)
            {
                var product = group.First();
                int quantity = group.Count();
                totalAmount += product.Price * quantity;
                Console.WriteLine($"Title: {product.Title}, Price: {product.Price}, SKU: {product.SKU}, Quantity: {quantity}");
            }
        }


    }
}
