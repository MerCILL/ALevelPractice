using Module2_HM2_OnlineStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderAddress { get; set; }
        public List<ProductEntity> productEntities { get; set; }

        public Order()
        {
            productEntities = new List<ProductEntity>();
        }

    }
}
