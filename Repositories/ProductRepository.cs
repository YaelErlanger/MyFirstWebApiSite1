﻿using Entities;
using Repositories;
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
        private readonly MyStore326659356Context _store326659356Context;
        public ProductRepository(MyStore326659356Context store326659356Context)
        {
            _store326659356Context = store326659356Context;
        }

        public async Task<IEnumerable<ProductsTbl>> GetProductsAsync(string? name, int? minPrice, int? maxPrice, int?[] CategoryIds)
        {
            var query = _store326659356Context.ProductsTbls.Where(product =>
            (name == null ? (true) : (product.Description.Contains(name)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((CategoryIds.Length == 0) ? (true) : (CategoryIds.Contains(product.CategoryId))))
            .OrderBy(product => product.Price)
            .Include(product => product.Category);
            List<ProductsTbl> products = await query.ToListAsync();
            return products;
        }
       

    }
}
