using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepositories : ICategoryRepositories
    {
        StshopContext _StshopContext;

        public CategoryRepositories(StshopContext stshopContext)
        {
            _StshopContext = stshopContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _StshopContext.Categories.ToListAsync();
        }
        public async Task<Category?> GetCategoryById(int id)
        {
            return await _StshopContext.Categories.FindAsync(id);
        }

    }
}
