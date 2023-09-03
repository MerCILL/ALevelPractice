using Module2_HM2_OnlineStore.Entities;
using Module2_HM2_OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Repositories
{
    internal class CustomerRepository
    {
        private readonly List<CustomerEntity> _customers = new List<CustomerEntity>();

        public string AddCustomer(string login, string firstName, string lastName, string email)
        {

            if (_customers.Any(x => x.Login == login))
                return null;

            if (_customers.Any(x => x.Email == email))
                return null;

            var customer = new CustomerEntity()
            {
                Login = login,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                OrderList = new List<OrderEntity>(),
                ShoppingCart = new ShoppingCart()
            };

            _customers.Add(customer);

            return login;

        }

        public CustomerEntity GetCustomer(string login) => _customers.FirstOrDefault(x => x.Login == login);
        public List<CustomerEntity> GetCustomers() => _customers.ToList();

    }
}
