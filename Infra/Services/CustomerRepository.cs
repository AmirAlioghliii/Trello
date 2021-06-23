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

        public async Task ChangeTaskStatus(int taskid, string Status)
        {
            await _context.UserTasks.SingleOrDefaultAsync(u => u.Id == taskid);
        }

        public async Task<IEnumerable<UserTask>> GetAllTasks(string userid)
        {
            return await _context.UserTasks.Where(u => u.UserId == userid).ToListAsync();
        }
    }
}
