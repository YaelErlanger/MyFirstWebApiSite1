using DTO;
using Entities;

namespace Services
{
    public interface IOrderServices
    {
        Task<OrdersTbl> addOrderToDB(OrdersTbl order);
        Task<IEnumerable<OrdersTbl>> GetOrdersAsync();
    }
}