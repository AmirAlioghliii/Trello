using Infra.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;

namespace Infra.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }

        private SqlConnection _sqlConnection;
        private IUserRepository _userRepository;
        private IUserTaskRepository _userTaskRepository;
        private ICategoryRepository _categoryRepository;

        public IDbConnection DbConnection => _sqlConnection ??= new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(DbConnection);

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(DbConnection);

        public IUserTaskRepository UserTaskRepository => _userTaskRepository ??= new UserTaskRepository(DbConnection);

       

        public async Task BeginTransactionAsync()
        {
        }

        public async Task CommitAsync()
        {
        }

        public async Task RollBackAsync()
        {
        }

        //public async Task<int> SaveChangesAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}
    }
}
