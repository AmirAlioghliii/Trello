using Infra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;

namespace Infra.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly ApplicationDbContext _context;

        public UserTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(UserTask task)
        {
            await _context.UserTasks.AddAsync(task);
        }

        public async Task<IEnumerable<UserTask>> GetAllTasks(string adminId)
        {
            return await _context.UserTasks.Where(u => u.AdminId == adminId).ToListAsync();
        }

        public async Task<IEnumerable<UserTask>> GetArchiveTasks(string adminId)
        {
            return await _context.UserTasks.Where(u => u.AdminId == adminId && u.Status == "Verify").ToListAsync();
        }

        public async Task<IEnumerable<UserTask>> GetDoneTasks(string adminId)
        {
            return await _context.UserTasks.Where(u => u.AdminId == adminId && u.Status == "Done").ToListAsync();
        }

        public async Task<UserTask> GetTaskById(int id)
        {
            var task = await _context.UserTasks.SingleOrDefaultAsync(u => u.Id == id);
            return task;
        }

        public async Task<IEnumerable<UserTask>> GetTasksByCategoryId(string userId, int categoryId)
        {
            return await _context.UserTasks.Where(u => u.UserId == userId && u.CategoryId == categoryId).ToListAsync();
        }
    }
}
