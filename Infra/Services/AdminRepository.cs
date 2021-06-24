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
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
           await _context.AddAsync(category);
        }

        public async Task AddTaskAsync(UserTask task)
        {
            await _context.UserTasks.AddAsync(task);
        }

        public async Task ChangeTaskStatus(int taskId, string status)
        {
           var task= await _context.UserTasks.SingleOrDefaultAsync(u => u.Id == taskId);
            task.Status = status;
        }

        public async Task<IEnumerable<UserTask>> GetAllTasks(string adminId)
        {
            return await _context.UserTasks.Where(u => u.AdminId == adminId).ToListAsync();
        }

        public async Task<IEnumerable<UserTask>> GetArchiveTasks(string adminId)
        {
            return await _context.UserTasks.Where(u => u.AdminId == adminId && u.Status == "Done").ToListAsync();
        }
    }
}
