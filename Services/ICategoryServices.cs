using Entities;

namespace Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CaegoriesTbl>> GetCategoriesAsync();
    }
}