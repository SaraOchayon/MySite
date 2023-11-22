using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : IOrderServices
    {
        private IOrderRepositories OrderRepository;

        public OrderServices(IOrderRepositories _orderRepositories)
        {
            OrderRepository = _orderRepositories;
        }
        public async Task<Order> GetOrders(Order order)
        {
            return await OrderRepository.AddOrder(order);
        }


    }
}
