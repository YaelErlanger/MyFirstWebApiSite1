using DTO;
using Entities;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<OrderServices> _logger;


        public OrderServices(IOrderRepository orderRepository, ILogger<OrderServices> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
           
        }

        public async Task<OrdersTbl> addOrderToDB(OrdersTbl order)
        {
             
            double correctSum = 0;
            IEnumerable<OrderItemTbl> items = order.OrderItemTbls;
           foreach(OrderItemTbl item in items)
            {
                correctSum +=await _orderRepository.getprice(item);
            }
            
            if(correctSum != order.OrderSum)
            {
                _logger.LogInformation("{1} tried to still!", order.UserId);
            }
            order.OrderSum = (int?)correctSum;
            return await _orderRepository.addOrderToDB(order);
        }
        public async Task<IEnumerable<OrdersTbl>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }
       
    }
}
