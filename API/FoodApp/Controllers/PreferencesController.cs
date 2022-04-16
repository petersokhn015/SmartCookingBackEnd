using Microsoft.AspNetCore.Mvc;
using Recipes.Data;
using Recipes.Repo;
using Recipes.Services;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly IPreferences _preferences;
        public PreferencesController(IPreferences preferences)
        {
            _preferences = preferences;
        }

        [HttpPost("Preference")]
        public async Task<ActionResult> AddPreference(UserPreferences preferences)
        {
            bool isCreated = await _preferences.AddUserPreferences(preferences);
            if (isCreated == true)
            {
                return Ok("Preference added");
            }
            else
            {
                return BadRequest("Preference not added");
            }
        }

        [HttpGet("Preference/{id}")]
        public async Task<ActionResult> GetPreference(int id)
        {
            var userPreferences = await _preferences.GetUserPreferences(id);

            if(userPreferences != null)
            {
                return Ok(userPreferences);
            }
            else
            {
                return BadRequest("Preference not found");
            }
        }

        [HttpGet("Preferences")]
        public async Task<ActionResult> GetPreferences()
        {
            var preferences = await _preferences.GetAllPreferences();
            if(preferences != null)
            {
                 return Ok(preferences);
            }
            else
            {
                return BadRequest("Preferences not found");
            }
        }

        [HttpPut("Preference")]
        public async Task<ActionResult> UpdatePreference(UserPreferences preference)
        {
            bool isUpdated = await _preferences.UpdatePreference(preference);
            if(isUpdated == true)
            {
                return Ok("Preference updated");
            }
            else
            {
                return BadRequest("Preference not updated");
            }
        }

        [HttpDelete("Preference")]
        public async Task<ActionResult> DeletePreference(int id)
        {
            bool isDeleted = await _preferences.DeletePreference(id);
            if(isDeleted == true)
            {
                
                return Ok("Preference deleted");
            }
            else
            {
                return BadRequest("Preference not deleted");
            }
        }


    }
}
