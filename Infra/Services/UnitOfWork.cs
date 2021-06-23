using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAdminRepository AdminRepository => throw new NotImplementedException();

        public ICustomerRepository CustomerRepository => throw new NotImplementedException();

        public Task BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task RollBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
