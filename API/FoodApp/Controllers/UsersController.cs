using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Recipes.Data;
using Recipes.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _users;
        public UsersController(IUsers users)
        {
            _users = users;
        }

        [HttpPost("User")]
        public async Task<ActionResult> Create(DTOUser userToAdd)
        {
            User user = new()
            {
                username = userToAdd.username,
                password = userToAdd.password,
            };

            bool isCreated = await _users.AddUser(user);
            if(isCreated == true)
            {
                return Ok("User added");
            }
            else
            {
                return BadRequest("User not added");
            }
        }

        [HttpGet("GetIdOfUser/{username}")]
        public async Task<ActionResult<int>> GetIdOfUser(string username)
        {
            var userId = await _users.GetIdOfUser(username);
            if(userId != -1)
            {
                return Ok(userId);
            }
            else
            {
                return NotFound("User not found");
            }
        }

        [HttpGet("GetPreferenceOfUser/{username}")]
        public async Task<ActionResult> GetPreference(string username)
        {
            var userPreferences = await _users.GetPreferenceOfUser(username);
            if(userPreferences != null)
            {
                return Ok(userPreferences);
            }
            else
            {
                return NotFound("Preferences not found for this user");
            }
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _users.GetUser(id);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User not found");
            }
        }

        [HttpGet("UserLoggedIn")]
        public async Task<bool> isUserLoggedIn([FromQuery] DTOUser user)
        {
            bool isUserFound = await _users.isUserExist(user);
            return isUserFound;
        }

        [HttpGet("UserExists")]
        public async Task<bool> isUserExist([FromQuery] string username)
        {
            bool isUserFound = await _users.isUserExist(username);
            return isUserFound;
        }

        [HttpGet("Users")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _users.GetAllUsers();
            if(users != null)
            {
                return Ok(users);
            }
            else
            {
                List<User> list = new();
                return Ok(list);
            }
        }

        [HttpPut("User")]
        public async Task<ActionResult> Update(User user)
        {
            bool isUpdated = await _users.UpdateUser(user);
            if(isUpdated == true)
            { 
                return Ok("User updated");
            }
            else
            {
                return BadRequest("User not updated");
            }
        }

        [HttpDelete("User")]
        public async Task<ActionResult> Delete(int id)
        {
            bool isDeleted = await _users.DeleteUser(id);
            if(isDeleted == true)
            {
                return Ok("User deleted");
            }
            else
            {
                return BadRequest("User not deleted");
            }
        }
    }
}
