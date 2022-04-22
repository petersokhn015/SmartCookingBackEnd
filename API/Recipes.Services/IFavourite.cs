using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IFavourite
    {
        Task<bool> AddFavouriteRecipe(DetailedRecipe detailedRecipe, int userId);
        Task<bool> RemoveFavouriteRecipe(int recipeId, int userId);
        Task<DetailedRecipe> GetDetailedFavouriteOfUserById(long recipeId, int userId);
        Task <List<RecipeDTO>> GetAllFavouritesOfUserById(int userId);
        Task<int> GetFavouritesCount();
        Task<List<DetailedRecipe>> GetAllDetailedFavouritesOfUserById(int userId);
    }
}
