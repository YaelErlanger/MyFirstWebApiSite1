using Entities;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CaegoriesTbl>> GetCategoriesAsync();
    }
}