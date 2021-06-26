using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;

namespace Infra.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IAdminRepository _adminRepository;
        private ICustomerRepository _customerRepository;
        private IUserRepository _userRepository;

        public IAdminRepository AdminRepository => _adminRepository ??= new AdminRepository(_context);

        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public async Task BeginTransactionAsync()
        {
           await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollBackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
