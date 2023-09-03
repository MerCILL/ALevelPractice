using Module2_HM2_OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Models
{
    internal class ShoppingCart
    {
        public List<Product> Products;

        public ShoppingCart()
        {
            Products = new List<Product>();
        }

    }
}
