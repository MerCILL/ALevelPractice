using Module2_HM2_OnlineStore;
using Module2_HM2_OnlineStore.Models;
using Module2_HM2_OnlineStore.Repositories;
using Module2_HM2_OnlineStore.Services;

var productRepository = new ProductRepository();
var productService = new ProductService(productRepository);


var customerRepository = new CustomerRepository();
var customerService = new CustomerService(customerRepository);


var orderRepository = new OrderRepository();
var orderService = new OrderService(orderRepository);

Shopping shopping = new Shopping(customerService, productService, orderService, new NotifyCustomer());

shopping.AddCustomer("customer1", "firstname1", "lastname1", "customer1@gmail.com");
shopping.AddCustomer("customer2", "firstname2", "lastname2", "customer2@gmail.com");
Console.WriteLine(new string('-', 50));

shopping.AddProduct("keyboard", 100m, 2);
shopping.AddProduct("mouse", 50m, 3);
shopping.AddProduct("keyboard", 100m, 5);
shopping.AddProduct("CPU", 1000m, 10);
Console.WriteLine(new string('-', 50));

shopping.ShowCustomersInfo();
Console.WriteLine(new string('-', 50));

shopping.ShowAllProducts();
Console.WriteLine(new string('-', 50));

shopping.AddProductsInShoppingCart("customer1", "fff");
shopping.AddProductsInShoppingCart("customer1", "customer1@gmail.com");
Console.WriteLine(new string('-', 50));

shopping.ShowCart("customer1");
Console.WriteLine(new string('-', 50));

shopping.ConfirmOrder("customer1");
Console.WriteLine(new string('-', 50));

shopping.ShowCart("customer1");
Console.WriteLine(new string('-', 50));

shopping.ShowOrders();
Console.WriteLine(new string('-', 50));

shopping.ShowAllProducts();
Console.WriteLine(new string('-', 50));

shopping.AddProductsInShoppingCart("customer1", "customer1@gmail.com");
Console.WriteLine(new string('-', 50));

shopping.ShowCart("customer1");
Console.WriteLine(new string('-', 50));

shopping.ConfirmOrder("customer1");
Console.WriteLine(new string('-', 50));

shopping.ShowOrdersByCustomer("customer1");