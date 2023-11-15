using Entities;

namespace Repositories
{
    public interface ICategoryRepositories
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category?> GetCategoryById(int id);
    }
}