using Module2_HM2_OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Models
{
    internal class Customer
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public List<OrderEntity> OrderList;
        public ShoppingCart ShoppingCart;

        public Customer() 
        {
            OrderList = new List<OrderEntity>();
            ShoppingCart = new ShoppingCart();
        }

     

    }
}
