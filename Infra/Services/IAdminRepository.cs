using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
    public interface IAdminRepository
    {
        Task AddTaskAsync(UserTask task);
        Task ChangeTaskStatus(int taskId, string status);
        Task AddCategory(Category category);
        Task<IEnumerable<UserTask>> GetAllTasks(string adminId);
        Task<IEnumerable<UserTask>> GetArchiveTasks(string adminId);
        Task<IEnumerable<UserTask>> GetDoneTasks(string adminId);

    }
}
