using Dapper;
using Infra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;

namespace Infra.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserTaskRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddTaskAsync(UserTask task)
        {
            string Query = "INSERT INTO UserTasks (Name, UserId, CategoryId,AdminId,TaskTime) VALUES (@Name, @UserId, @CategoryId,@AdminId,@TaskTime) ";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            await _dbConnection.QueryAsync<UserTask>(Query,
                new { @Name = task.Name, @UserId = task.UserId, @CategoryId = task.CategoryId, @AdminId = task.AdminId, @TaskTime = task.TaskTime });
        }

        public async Task<IEnumerable<UserTask>> GetAllTasks(string adminId)
        {
            string Query = "select * from UserTasks where AdminId=@adminID";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            return await _dbConnection.QueryAsync<UserTask>(Query, new { @adminID = adminId });
        }

        public async Task<IEnumerable<UserTask>> GetArchiveTasks(string adminId)
        {
            string Query = "select * from UserTasks Where AdminId=@adminId and Status = 'Verify'";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            return await _dbConnection.QueryAsync<UserTask>(Query, new { adminId = adminId });
        }

        public async Task<IEnumerable<UserTask>> GetDoneTasks(string adminId)
        {
            string Query = "select * from UserTasks Where AdminId=@adminId and Status = 'Done'";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            return await _dbConnection.QueryAsync<UserTask>(Query, new { adminId = adminId });
        }

        public async Task<UserTask> GetTaskById(int id)
        {
            string Query = "select * from UserTasks where Id =@id";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            return await _dbConnection.QuerySingleOrDefaultAsync<UserTask>(Query, new { @id = id });
        }

        public async Task<IEnumerable<UserTask>> GetTasksByCategoryId(string userId, int categoryId)
        {
            string Query = "select * from UserTasks Where UserId = @userId and UserId =@categoryId ";
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            return await _dbConnection.QueryAsync<UserTask>(Query, new { @userId = userId, @categoryId = categoryId });

        }

        public async Task UpdateTaskAsnc(UserTask task)
        {
            string Query = "UPDATE UserTasks set Status=@status ,TaskTime=@TaskTime Where Id=@Id";

            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();

            }
            await _dbConnection.QueryAsync<UserTask>(Query, new { @status = task.Status, @TaskTime = task.TaskTime, @Id = task.Id });

        }
    }
}
