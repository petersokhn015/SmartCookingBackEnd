using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IPreferences
    {
        Task<bool> AddUserPreferences(UserPreferences preferences);

        Task<UserPreferences> GetUserPreferences(int id);

        Task<Dictionary<string, UserPreferences>> GetAllPreferences();

        Task<bool> UpdatePreference(UserPreferences preference);

        Task<bool> DeletePreference(int id);
        
    }
}
