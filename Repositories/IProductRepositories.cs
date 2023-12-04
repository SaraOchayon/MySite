using Entities;

namespace Repositories
{
    public interface IProductRepositories
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}