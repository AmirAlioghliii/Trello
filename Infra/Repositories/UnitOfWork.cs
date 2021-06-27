using Infra.Repositories;
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

        private IUserRepository _userRepository;
        private IUserTaskRepository _userTaskRepository;
        private ICategoryRepository _categoryRepository;

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);

        public IUserTaskRepository UserTaskRepository => _userTaskRepository ??= new UserTaskRepository(_context);

        public async Task BeginTransactionAsync()
        {
        }

        public async Task CommitAsync()
        {
        }

        public async Task RollBackAsync()
        {
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
