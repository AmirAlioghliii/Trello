using Infra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;

namespace Infra.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ChangeTaskStatus(int taskId, string satus)
        {
           var user = await _context.UserTasks.SingleOrDefaultAsync(u => u.Id == taskId);
            user.Status = satus;
            
        }

        public async Task<IEnumerable<UserTask>> GetAllTasks(string userId)
        {
            return await _context.UserTasks.Where(u => u.UserId == userId).ToListAsync();
        }
    }
}
