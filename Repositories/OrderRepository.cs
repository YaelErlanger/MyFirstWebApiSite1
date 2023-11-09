using Entities;
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
        private readonly Store326659356Context _store326659356Context;
        public OrderRepository(Store326659356Context store326659356Context)
        {
            _store326659356Context = store326659356Context;
        }
        public async Task<OrdersTbl> addOrderToDB(OrdersTbl order)
        {
            await _store326659356Context.OrdersTbls.AddAsync(order);
            await _store326659356Context.SaveChangesAsync();

            return order;
        }
        public async Task<IEnumerable<OrdersTbl>> GetOrdersAsync()
        {
            return await _store326659356Context.OrdersTbls.ToListAsync();
        }

    }
}
