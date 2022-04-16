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
    public class UsersRepo : IUsers
    {
        private readonly IFirebaseConfig _config;
        private readonly IFirebaseClient _client;
        private readonly IConfiguration _configuration;

        public UsersRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _config = new FirebaseConfig()
            {
                AuthSecret = _configuration["FirebaseCredentials:Secret"],
                BasePath = _configuration["FirebaseCredentials:BaseUrl"]
            };
            _client = new FireSharp.FirebaseClient(_config);
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                var usercount = await GetCountUsers();
                int Id = usercount + 1;
                user.Id = Id;
                var setter = _client.Set("Users/User" + Id, user);
                return true;
            }
            catch
            {
                return false;

            }
        }

        public async Task<int> GetIdOfUser(string username)
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
                return -1;
            }
        }

        public async Task<List<Preferences>> GetPreferenceOfUser(string email)
        {
            try
            {
                var result = await _client.GetAsync("Preferences");
                var userId = await GetIdOfUser(email);
                List<Preferences> preferences = new();
                Dictionary<string, UserPreferences> userPreferences = result.ResultAs<Dictionary<string, UserPreferences>>();
                foreach (var userPreference in userPreferences)
                {
                    if (userPreference.Value.userId.Equals(userId))
                    {
                        preferences = userPreference.Value.preferences;
                    }
                }

                return preferences;
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                var result = _client.Get("Users/User" + id);
                User user = result.ResultAs<User>();
                return user;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Dictionary<string, User>> GetAllUsers()
        {
            try
            {
                var result = await _client.GetAsync("Users");
                Dictionary<string, User> data = result.ResultAs<Dictionary<string, User>>();
                return data;
            }
            catch
            {
                return null;
            }
        }

        private async Task<int> GetCountUsers()
        {
            int count = 0;
            try
            {

                var result = await _client.GetAsync("Users");
                Dictionary<string, User> data = result.ResultAs<Dictionary<string, User>>();
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
        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                var setter = _client.Update("Users/User" + user.Id, user);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var setter = _client.Delete("Users/User" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> isUserExist(DTOUser user)
        {
            try
            {
                var result = await _client.GetAsync("Users");
                Dictionary<string, DTOUser> data = result.ResultAs<Dictionary<string, DTOUser>>();
                foreach(var item in data)
                {
                    if(item.Value.username.Equals(user.username) && item.Value.password.Equals(user.password))
                    {
                        return true;
                    }
                }

                return false;

            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> isUserExist(string username)
        {
            try
            {
                var result = await _client.GetAsync("Users");
                Dictionary<string, DTOUser> data = result.ResultAs<Dictionary<string, DTOUser>>();
                foreach (var item in data)
                {
                    if (item.Value.username.Equals(username))
                    {
                        return true;
                    }
                }

                return false;

            }
            catch
            {
                return false;
            }
        }
    }
}
