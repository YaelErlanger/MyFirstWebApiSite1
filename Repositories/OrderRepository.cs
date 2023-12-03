using Entities;
using Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyStore326659356Context _store326659356Context;
        public OrderRepository(MyStore326659356Context store326659356Context)
        {
            _store326659356Context = store326659356Context;
        }
        public async Task<OrdersTbl> addOrderToDB(OrdersTbl order)
        {
            await _store326659356Context.OrdersTbls.AddAsync(order);
            //await _store326659356Context.OrderItemTbls.AddAsync((OrderItemTbl)order.OrderItemTbls);
            await _store326659356Context.SaveChangesAsync();
           

            return order;
        }
        public async Task<IEnumerable<OrdersTbl>> GetOrdersAsync()
        {
            return await _store326659356Context.OrdersTbls
                .Include(order => order.User)
                //.Include(order => order.OrderItemTbls)   
                .ToListAsync();
        }
        public async Task<double> getprice(OrderItemTbl order)
        {
            ProductsTbl product = _store326659356Context.ProductsTbls.Where(item => item.ProductId == order.ProductId).FirstOrDefault();
            return (double)product.Price;
        }

    }
}
