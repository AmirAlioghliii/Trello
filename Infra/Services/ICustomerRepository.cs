using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
     public interface ICustomerRepository
    {
        Task<IEnumerable<UserTask>> GetAllTasks(string userid);
        Task ChangeTaskStatus(int TaskId, string Status);
    }
}
