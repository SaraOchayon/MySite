using Entities;

namespace Repositories
{
    public interface IOrderRepositories
    {
        Task<Order> AddOrder(Order order);
    }
}