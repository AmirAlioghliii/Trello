using Dapper;
using Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;
using Trello_.Models;

namespace Infra.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }



        public async Task<IEnumerable< UserTask>> GetAllTasks()
        {
            string query = "select * from UserTasks";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            return await _dbConnection.QueryAsync<UserTask>(query);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            string query = "select * from AspNetUsers where Email =@email";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            return await _dbConnection.QuerySingleOrDefaultAsync<ApplicationUser>(query, new { @email= email });
        }

        public async Task<ApplicationUser> GetUserById( string id)
        {
            string query = "select * from AspNetUsers where Id=@Id";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            return await _dbConnection.QuerySingleOrDefaultAsync<ApplicationUser>(query, new { @Id = id });
        }
    }
}
