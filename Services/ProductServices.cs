using Entities;
using Repositories;
using System.Collections;

namespace Services
{
    public class ProductServices : IProductServices
    {
        private IProductRepositories ProductRepository;
        public ProductServices(IProductRepositories _productRepositories)
        {
            ProductRepository = _productRepositories;
        }
        public async  Task<IEnumerable<Product>> GetProducts()
        {
            return await ProductRepository.GetProducts();
        }

    }
}
