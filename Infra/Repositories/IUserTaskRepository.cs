using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public interface IUserTaskRepository
    {
        Task AddTaskAsync(UserTask task);
        Task UpdateTaskAsnc(UserTask task);
        Task<UserTask> GetTaskById(int id);
        Task<IEnumerable<UserTask>> GetTasksByCategoryId(string userId, int categoryId);
        Task<IEnumerable<UserTask>> GetAllTasks(string adminId);

        Task<IEnumerable<UserTask>> GetArchiveTasks(string adminId);
        Task<IEnumerable<UserTask>> GetDoneTasks(string adminId);

    }
}
