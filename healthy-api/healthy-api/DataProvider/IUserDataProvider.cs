using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using healthy_api.Models;

namespace healthy_api.DataProvider
{
    public interface IUserDataProvider
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int UserId);

        Task AddUser(User product);

        Task UpdateUser(User product);

        Task DeleteUser(int UserId);

    }
}
