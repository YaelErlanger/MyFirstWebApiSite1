using Entities;

namespace Services
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductsTbl>> GetProductsAsync( string? name,int? minPrice, int? maxPrice, int?[] CategoryIds);
        Task<IEnumerable<ProductsTbl>> GetProductsByCategoryIdAsync(int categoryId);

    }
}