using Dapper;
using Infra.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;

namespace Infra.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public CategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddCategory(Category category)
        {
            string Query = "Insert Into Categories (Name ) Values (@Name )";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            await _dbConnection.QueryAsync<Category>(Query, new { @Id = category.Id, @Name = category.Name});
        }

    }
}
