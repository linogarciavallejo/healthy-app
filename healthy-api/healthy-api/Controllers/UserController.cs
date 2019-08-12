using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using healthy_api.DataProvider;
using healthy_api.Models;
using Microsoft.AspNetCore.Cors;

namespace healthy_api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserDataProvider userDataProvider;

        public UserController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await this.userDataProvider.GetUsers();
        }

        [HttpGet("{UserId}")]
        public async Task<User> Get(int UserId)
        {
            return await this.userDataProvider.GetUser(UserId);
        }

        [HttpPut("{UserId}")]
        public async Task Put(int UserId, [FromBody]User user)
        {
            await this.userDataProvider.UpdateUser(user);
        }

        [HttpDelete("{UserId}")]
        public async Task Delete(int UserId)
        {
            await this.userDataProvider.DeleteUser(UserId);
        }

    }
}
