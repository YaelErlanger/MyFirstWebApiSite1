using DTO;
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
        IProductRepository _productRepository; 

        public OrderServices(IOrderRepository orderRepository,IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository; 
        }

        public async Task<OrdersTbl> addOrderToDB(OrdersTbl order)
        {
            //double sum = order.OrderSum;
            //var correctSum = 0;
            //IEnumerable<OrderItemTbl> items = order.OrderItemTbls;
            //IEnumerable<ProductsTbl> products = await _productRepository.GetProductsAsync();

            //foreach (ProductsTbl product in products)
            //{
            //    foreach (OrderItemTbl item in items)
            //    {
            //        if (item.ProductId == product.ProductId)
            //            correctSum += product.Price;
            //    }
            //}
            //if(correctSum != sum)
            //{
            //    //send to logger
            //}
            //order.OrderSum = correctSum;
            return await _orderRepository.addOrderToDB(order);
        }
        public async Task<IEnumerable<OrdersTbl>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }
       
    }
}
