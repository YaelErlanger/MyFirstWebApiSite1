using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : IOrderServices
    {
        IOrderRepository _orderRepository;

        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrdersTbl> addOrderToDB(OrdersTbl order)
        {

            return await _orderRepository.addOrderToDB(order);
        }
        public async Task<IEnumerable<OrdersTbl>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }

    }
}
