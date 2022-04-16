using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IUsers
    {
        Task<bool> AddUser(User user);

        Task<int> GetIdOfUser(string email);

        Task<List<Preferences>> GetPreferenceOfUser(string email);

        Task<User> GetUser(int id);

        Task<Dictionary<string, User>> GetAllUsers();

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(int id);
        Task<bool> isUserExist(DTOUser user);
        Task<bool> isUserExist(string username);
    }
}
