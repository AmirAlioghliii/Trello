using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;

namespace Infra.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCategory(Category category)
        {
            await _context.AddAsync(category);
        }
    }
}
