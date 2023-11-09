using Entities;

namespace Services
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductsTbl>> GetProductsAsync();
        Task<IEnumerable<ProductsTbl>> GetProductsByCategoryIdAsync(int categoryId);

    }
}