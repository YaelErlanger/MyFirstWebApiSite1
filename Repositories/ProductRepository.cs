using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Store326659356Context _store326659356Context;
        public ProductRepository(Store326659356Context store326659356Context)
        {
            _store326659356Context = store326659356Context;
        }

        public async Task<IEnumerable<ProductsTbl>> GetProductsAsync()
        {
            return await _store326659356Context.ProductsTbls.ToListAsync();
        }
        public async Task<IEnumerable<ProductsTbl>> GetProductsbyCategoryIdAsync(int categoryId)
        {
            return await _store326659356Context.ProductsTbls.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

    }
}
