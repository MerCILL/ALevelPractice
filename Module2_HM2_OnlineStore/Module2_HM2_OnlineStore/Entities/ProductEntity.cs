using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Entities
{
    internal class ProductEntity
    {
        public string Id { get; set;  }
        public string SKU { get; set; } // Stock Keeping Unit
        public string Title { get; set; }
        public decimal Price { get; set; }

    }
}
