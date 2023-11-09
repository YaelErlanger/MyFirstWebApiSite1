using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CaegoriesTbl>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }
    }
}
