using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductsTbl>> GetProductsAsync();
        Task<IEnumerable<ProductsTbl>> GetProductsbyCategoryIdAsync(int categoryId);
    }
}