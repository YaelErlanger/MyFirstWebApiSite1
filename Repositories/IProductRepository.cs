using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductsTbl>> GetProductsAsync(string? name, int? minPrice, int? maxPrice, int?[] CategoryIds);
       
    }
}