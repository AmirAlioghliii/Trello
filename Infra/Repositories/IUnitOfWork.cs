using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();
        public ICategoryRepository CategoryRepository { get; }
        public IUserTaskRepository UserTaskRepository { get; }
        public IUserRepository UserRepository { get; }
    }
}
