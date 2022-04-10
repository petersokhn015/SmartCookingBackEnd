using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Recipes.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IFirebaseConfig _config;
        private readonly IFirebaseClient _client;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
            _config = new FirebaseConfig()
            {
                AuthSecret = _configuration["FirebaseCredentials:Secret"],
                BasePath = _configuration["FirebaseCredentials:BaseUrl"]
            };
            _client = new FireSharp.FirebaseClient(_config);
        }

        [HttpPost("User")]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                var usercount = await GetCountUsers();
                int Id = usercount.Value + 1;
                user.Id = Id;
                var setter = _client.Set("Users/User" + Id, user);
                return Ok("User added");
            }
            catch
            {
                return BadRequest("User not added");
            }
        }

        [HttpGet("GetIdOfUser/{username}")]
        public async Task<ActionResult<int>> GetIdOfUser(string username)
        {
            try
            {
                var result = await _client.GetAsync("Users");
                int Id = 0;
                Dictionary<string, User> data = result.ResultAs<Dictionary<string, User>>();
                foreach (var user in data)
                {
                    if (user.Value.username.Equals(username))
                    {
                        Id = user.Value.Id;
                    }
                }

                return Id;
            }
            catch
            {
                return BadRequest("User not found");
            }
        }

        [HttpGet("GetPreferenceOfUser/{Id}")]
        public async Task<ActionResult<List<Preferences>>> GetPreferenceOfUser(int Id)
        {
            try
            {
                var result = await _client.GetAsync("Preferences");
                List<Preferences> preferences = new();
                Dictionary<string, UserPreferences> data = result.ResultAs<Dictionary<string, UserPreferences>>();
                foreach (var user in data)
                {
                    if (user.Value.userId.Equals(Id))
                    {
                       preferences = user.Value.preferences;
                    }
                }

                return preferences;
            }
            catch
            {
                return BadRequest("User not found");
            }
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = _client.Get("Users/User" + id);
                User user = result.ResultAs<User>();
                return Ok(user);
            }
            catch
            {
                return BadRequest("User not found");
            }
        }

        [HttpGet("Users")]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                var result = await _client.GetAsync("Users");
                Dictionary<string, User> data = result.ResultAs<Dictionary<string, User>>();
                return Ok(data);
            }
            catch
            {
                return BadRequest("Users not found");
            }
        }

        private async Task<ActionResult<int>> GetCountUsers()
        {
            int count = 0;
            try
            {
                
                var result = await _client.GetAsync("Users");
                Dictionary<string, User> data = result.ResultAs<Dictionary<string, User>>();
                if(data != null)
                {
                    count = data.Count;
                }
                return count;
            }
            catch
            {
                return count;
            }
        }

        [HttpPut("User")]
        public async Task<ActionResult> Update(User user)
        {
            try
            {
                var setter = _client.Update("Users/User" + user.Id, user);
                return Ok("User updated");
            }
            catch
            {
                return BadRequest("User not updated");
            }
        }

        [HttpDelete("User")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var setter = _client.Delete("Users/User" + id);
                return Ok("User deleted");
            }
            catch
            {
                return BadRequest("User not deleted");
            }
        }
    }
}
