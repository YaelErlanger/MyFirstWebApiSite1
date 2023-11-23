using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Store326659356Context _store326659356Context;
        public CategoryRepository(Store326659356Context store326659356Context)
        {
            _store326659356Context = store326659356Context;
        }

        public async Task<IEnumerable<CaegoriesTbl>> GetCategoriesAsync()
        {
            return await _store326659356Context.CaegoriesTbls.ToListAsync();
        }
    }
}
