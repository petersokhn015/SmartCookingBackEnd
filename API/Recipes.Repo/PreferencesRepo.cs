using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Extensions.Configuration;
using Recipes.Data;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Repo
{
    public class PreferencesRepo  : IPreferences
    {
        private readonly IFirebaseConfig _config;
        private readonly IFirebaseClient _client;
        private readonly IConfiguration _configuration;
        public PreferencesRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _config = new FirebaseConfig()
            {
                AuthSecret = _configuration["FirebaseCredentials:Secret"],
                BasePath = _configuration["FirebaseCredentials:BaseUrl"]
            };
            _client = new FireSharp.FirebaseClient(_config);
        }

        public async Task<bool> AddUserPreferences(UserPreferences Preferences)
        {
            try
            {
                var prefcount = await GetCountPreferences();
                var allPrefs = await GetAllPreferences();
                int Id = prefcount + 1;

                foreach (var pref in allPrefs.Values)
                {
                    if(pref.userId == Preferences.userId)
                    {
                        Preferences.Id = pref.Id;
                        Id = Preferences.Id;
                    }
                }

                
                Preferences.Id = Id;
                var setter = _client.Set("Preferences/UserPreference" + Id, Preferences);
                return true;
            }
            catch
            {
                return false;
            }
                
        }

        public async Task<UserPreferences> GetUserPreferences(int id)
        {
            try
            {
                var result = await _client.GetAsync("Preferences/UserPreference" + id);
                UserPreferences userPref = result.ResultAs<UserPreferences>();
                return userPref;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Dictionary<string, UserPreferences>> GetAllPreferences()
        {
            try
            {
                var result = await _client.GetAsync("Preferences");
                Dictionary<string, UserPreferences> data = result.ResultAs<Dictionary<string, UserPreferences>>();
                return data;
            }
            catch
            {
                return null;
            }
        }

        private async Task<int> GetCountPreferences()
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
                return -1;
            }
        }

        public async Task<bool> UpdatePreference(UserPreferences preference)
        {
            try
            {
                var setter = await _client.UpdateAsync("Preferences/UserPreference" + preference.Id, preference);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeletePreference(int id)
        {
            try
            {
                var setter = await _client.DeleteAsync("Preferences/UserPreference" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
