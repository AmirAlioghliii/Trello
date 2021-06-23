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
        public IAdminRepository AdminRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
    }
}
