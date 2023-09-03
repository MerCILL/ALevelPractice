using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Entities
{
    internal class OrderEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderAddress { get; set; }
        public List<ProductEntity> productEntities { get; set; }

    }
}
