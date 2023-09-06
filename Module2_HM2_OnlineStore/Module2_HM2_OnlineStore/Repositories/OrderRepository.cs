using Module2_HM2_OnlineStore.Entities;
using Module2_HM2_OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Repositories
{
    internal class OrderRepository
    {
        private readonly List<OrderEntity> _orders = new List<OrderEntity>();
        private static int nextId = 0;

        public int AddOrder(string orderAddress, List<ProductEntity> productsEntities)
        {
            var order = new OrderEntity()
            {
                Id = ++nextId,
                OrderDate = DateTime.UtcNow,
                OrderAddress = orderAddress,
                productEntities = productsEntities
            };

            _orders.Add(order);

            return order.Id;
        }

        public OrderEntity GetOrder(int id) => _orders.FirstOrDefault(x => x.Id == id);
        public List<OrderEntity> GetOrders() => _orders.ToList();

    }
}
