using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class ProductRepositories : IProductRepositories
    {
        StshopContext _StshopContext;

        public ProductRepositories(StshopContext stshopContext)
        {
            _StshopContext = stshopContext;
        }


        public async Task<IEnumerable<Product>> GetProducts()
        {
            return (IEnumerable<Product>)await _StshopContext.Products.FindAsync();
        }
    }
}
