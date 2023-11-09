using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<OrdersTbl> addOrderToDB(OrdersTbl order);
        Task<IEnumerable<OrdersTbl>> GetOrdersAsync();
    }
}