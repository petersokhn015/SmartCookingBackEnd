using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Recipes.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly IFirebaseConfig _config;
        private readonly IFirebaseClient _client;
        private readonly IConfiguration _configuration;
        public PreferencesController(IConfiguration configuration)
        {
            _configuration = configuration;
            _config = new FirebaseConfig()
            {
                AuthSecret = _configuration["FirebaseCredentials:Secret"],
                BasePath = _configuration["FirebaseCredentials:BaseUrl"]
            };
            _client = new FireSharp.FirebaseClient(_config);
        }

        [HttpPost("Preference")]
        public async Task<ActionResult> Create(UserPreferences preferences)
        {
            try
            {
                var prefcount = await GetCountPreferences();
                int Id = prefcount.Value + 1;
                preferences.Id = Id;
                var setter = _client.Set("Preferences/UserPreference" + Id, preferences);
                return Ok("Preference added");
            }
            catch
            {
                return BadRequest("Preference not added");
            }
        }

        [HttpGet("Preference/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = _client.Get("Preferences/UserPreference" + id);
                UserPreferences userPref = result.ResultAs<UserPreferences>();
                return Ok(userPref);
            }
            catch
            {
                return BadRequest("Preference not found");
            }
        }

        [HttpGet("Preferences")]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                var result = await _client.GetAsync("Preferences");
                Dictionary<string, UserPreferences> data = result.ResultAs<Dictionary<string, UserPreferences>>();
                return Ok(data);
            }
            catch
            {
                return BadRequest("Preferences not found");
            }
        }

        private async Task<ActionResult<int>> GetCountPreferences()
        {
            int count = 0;
            try
            {

                var result = await _client.GetAsync("Preferences");
                Dictionary<string, UserPreferences> data = result.ResultAs<Dictionary<string, UserPreferences>>();
                if (data != null)
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



        [HttpPut("Preference")]
        public async Task<ActionResult> Update(UserPreferences preference)
        {
            try
            {
                var setter = _client.Update("Preferences/UserPreference" + preference.Id, preference);
                return Ok("Preference updated");
            }
            catch
            {
                return BadRequest("Preference not updated");
            }
        }

        [HttpDelete("Preference")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var setter = _client.Delete("Preferences/UserPreference" + id);
                return Ok("Preference deleted");
            }
            catch
            {
                return BadRequest("Preference not deleted");
            }
        }


    }
}
