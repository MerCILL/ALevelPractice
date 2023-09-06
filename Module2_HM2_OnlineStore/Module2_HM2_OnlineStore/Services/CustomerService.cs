using Module2_HM2_OnlineStore.Entities;
using Module2_HM2_OnlineStore.Models;
using Module2_HM2_OnlineStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Services
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        private CustomerEntity _Customer { get; set; }
        private  List<Customer> _Customers { get; set; }

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public string AddCustomer(string login, string firstName, string lastName, string email)
        {
            _customerRepository.AddCustomer(login, firstName, lastName, email);
            return login;
        }

        public Customer GetCustomer(string login)
        {
             _Customer = _customerRepository.GetCustomer(login);

            return new Customer()
            {
                Login = _Customer.Login,
                FirstName = _Customer.FirstName,
                LastName = _Customer.LastName,
                Email = _Customer.Email,
                FullName = $"{_Customer.FirstName} {_Customer.LastName}",
                OrderList = _Customer.OrderList,
                ShoppingCart = _Customer.ShoppingCart
            };

        }

        public List<Customer> GetCustomers() 
        {
            _Customers = new List<Customer>();
            foreach (var item in _customerRepository.GetCustomers())
            {
                _Customers.Add(new Customer()
                {
                    Login = item.Login,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    FullName = $"{item.FirstName} {item.LastName}",
                    OrderList = item.OrderList
                });
            }
            return _Customers;
        }

        public void ShowCustomerInfo(string login)
        {
            var customer = GetCustomer(login);
            Console.WriteLine($"Login: {customer.Login}, FullName: {customer.FullName}, Email: {customer.Email}");

        }

        public void ShowCustomersInfo()
        {
            foreach (var item in GetCustomers())
            {
                Console.WriteLine($"Login: {item.Login}, FullName: {item.FullName}, Email: {item.Email}");
            }
        }

        public bool checkCustomerIsNull(string login)
        {
            if (_customerRepository.GetCustomer(login) == null) return true;
            return false;
        }

        public bool checkCartIsNull(string login)
        {
            if(_customerRepository.GetCustomer(login).ShoppingCart == null) return true;
            return false;
        }

        public bool checkCartIsEmpty(string login) 
        {
            if (_customerRepository.GetCustomer(login).ShoppingCart.Products.Count == 0) return true;
            return false;
        }

        public void ShowCart(string login)
        {

            if (checkCustomerIsNull(login)) return;

            if (checkCartIsNull(login)) return;

            if (checkCartIsEmpty(login)) return;

            var products = _customerRepository.GetCustomer(login).ShoppingCart.Products.GroupBy(x => x.SKU)
                .Select(group => new
                {
                    SKU = group.Key,
                    Title = group.First().Title,
                    Price = group.First().Price,
                    Quantity = group.Count()
                });

            decimal totalAmount = products.Sum(x => x.Price * x.Quantity);

            Console.WriteLine($"Shopping cart of customer {login}");

            foreach (var item in products)
            {
                Console.WriteLine($"Title: {item.Title} | SKU: {item.SKU} | Price: {item.Price} X {item.Quantity}");
            }

            Console.WriteLine($"Total Price: {totalAmount}");
        }
        
    }
}
