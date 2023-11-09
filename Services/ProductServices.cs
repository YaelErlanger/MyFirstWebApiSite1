using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices : IProductServices
    {
        IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductsTbl>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }
        public async Task<IEnumerable<ProductsTbl>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _productRepository.GetProductsbyCategoryIdAsync(categoryId);
        }
    }
}
