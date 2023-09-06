using Module2_HM2_OnlineStore.Entities;
using Module2_HM2_OnlineStore.Models;
using Module2_HM2_OnlineStore.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Services
{
    internal class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private OrderEntity _order;
        private List<Order> _orders;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public int AddOrder(DateTime orderDate, string orderAddress, List<Product> product)
        {
            List<ProductEntity> productEntities = new List<ProductEntity>();
            foreach (var item in product)
                productEntities.Add(new ProductEntity {Id = item.Id, SKU = item.SKU, Title = item.Title, Price = item.Price });

            var id = _orderRepository.AddOrder(orderAddress, productEntities);
            return id;
        }

        public List<Order> GetOrders()
        {
            _orders = new List<Order>();
            foreach (var item in _orderRepository.GetOrders())
            {
                _orders.Add(new Order()
                {
                    Id = item.Id,
                    OrderDate = item.OrderDate,
                    OrderAddress = item.OrderAddress,
                    productEntities = item.productEntities
                });
            }

            return _orders;
        }

        public Order GetOrder(int id)
        {
            _order = _orderRepository.GetOrder(id);

            return new Order()
            {
                Id = _order.Id,
                OrderDate = _order.OrderDate,
                OrderAddress = _order.OrderAddress,
                productEntities= _order.productEntities
            };
        }

    
    }
}
