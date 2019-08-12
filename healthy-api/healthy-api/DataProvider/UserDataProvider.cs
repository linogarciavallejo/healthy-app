using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using healthy_api.Models;

namespace healthy_api.DataProvider
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly string connectionString = "Server=localhost;Database=Healthy;MultipleActiveResultSets=true;User ID=sa;Password=CanisMajoris19";

        private SqlConnection sqlConnection;

        //Add user
        public async Task AddUser(User user)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", user.UserId);
                dynamicParameters.Add("@Name", user.Name);
                dynamicParameters.Add("@Email", user.Email);

                await sqlConnection.ExecuteAsync(
                    "spAddUser",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        //Delete user
        public async Task DeleteUser(int UserId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", UserId);
                await sqlConnection.ExecuteAsync(
                    "spDeleteUser",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        //Get user by Id
        public async Task<User> GetUser(int UserId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", UserId);
                return await sqlConnection.QuerySingleOrDefaultAsync<User>(
                    "SELECT * FROM [Users] WHERE UserId= @UserId",
                    dynamicParameters,
                    commandType: CommandType.Text);
            }
        }

        //Get all users
        public async Task<IEnumerable<User>> GetUsers()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<User>(
                    "SELECT * FROM [Users] ORDER BY [name]",
                    null,
                    commandType: CommandType.Text);
            }
        }

        //Update user
        public async Task UpdateUser(User user)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", user.UserId);
                dynamicParameters.Add("@UserName", user.Name);
                dynamicParameters.Add("@Email", user.Email);
                //dynamicParameters.Add("@Password", user.Password);
                await sqlConnection.ExecuteAsync(
                    "spUpdateUser",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


    }
}
