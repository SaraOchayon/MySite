using Entities;

namespace Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category?> GetCategoryById(int id);
    }
}