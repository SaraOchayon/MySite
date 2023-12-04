﻿using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ProductRepositories :  IProductRepositories
    {
        StshopContext _StshopContext;

        public ProductRepositories(StshopContext stshopContext)
        {
            _StshopContext = stshopContext;
        }


        public async Task<IEnumerable<Product>> GetProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _StshopContext.Products.Where(product =>
           (desc == null ? (true) : (product.Description.Contains(desc)))
           && ((minPrice == null) ? (true) : (product.Price >= minPrice))
           && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
           && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
           .OrderBy(product => product.Price);

            List<Product> products = await query.ToListAsync();
            // products.Include(p => p.category).ToListAsync();
            return products;

        }
        public async Task<Product> GetProductById(int id)
        {
            return await _StshopContext.Products.Where(p => p.ProdId == id).FirstOrDefaultAsync();
        }

    }
}
