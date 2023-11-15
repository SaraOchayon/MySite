using Entities;

namespace Repositories
{
    public interface IProductRepositories
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}