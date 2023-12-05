using Entities;
using Microsoft.Extensions.Logging;
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
        private IProductRepositories ProductRepository;
        private readonly ILogger<OrderServices> _logger;

        public OrderServices(IOrderRepositories orderRepository, IProductRepositories productRepository, ILogger<OrderServices> logger)
        {
            OrderRepository = orderRepository;
            ProductRepository = productRepository;
            _logger = logger;
        }

        public async Task<Order> AddOrders(Order order)
        {
            double totalSum = 0;
            foreach (OrderItem item in order.OrderItems)
            {
                 Product p= await ProductRepository.GetProductById(item.ProdId);
                totalSum += p.Price;

            }
            if (totalSum != order.OrderSum)
            {
                _logger.LogInformation("someone want to stole you!!!!!!!!!!!!!!!!!!!");
                order.OrderSum = totalSum;
            }
            order.OrderSum = (int)order.OrderSum;
            return await OrderRepository.AddOrder(order);
        }


    }
}
