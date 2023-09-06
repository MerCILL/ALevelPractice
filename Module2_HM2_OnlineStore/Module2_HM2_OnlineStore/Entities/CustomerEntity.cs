using Module2_HM2_OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Entities
{
    internal class CustomerEntity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OrderEntity> OrderList { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
