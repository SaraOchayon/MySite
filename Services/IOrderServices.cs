using Entities;

namespace Services
{
    public interface IOrderServices
    {
        Task<Order> GetOrders(Order order);
    }
}