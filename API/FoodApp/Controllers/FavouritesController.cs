using Microsoft.AspNetCore.Mvc;
using Recipes.Data;
using Recipes.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavourite favouriteInterface;
        private readonly IRecipe recipeInterface;
        public FavouritesController(IFavourite favouriteInterface, IRecipe recipeInterface)
        {
            this.favouriteInterface = favouriteInterface;
            this.recipeInterface = recipeInterface;
        }

        [HttpPost("Favourite")]
        public async Task<ActionResult> AddFavourite([FromBody] DetailedRecipe recipe, int userId)
        {
            if (recipe == null)
            {
                return BadRequest("Favourite Not Added");
            }

            bool hasBeenAdded = await favouriteInterface.AddFavouriteRecipe(recipe, userId);

            if (hasBeenAdded)
            {
                return Ok("Favourite Added");
            }
            else
            {
                return BadRequest("Favourite Not Added");
            }
        }

        [HttpGet("Favourite")]
        public async Task<List<RecipeDTO>> GetAllVafouritesByUserId(int userId)
        {
            List<RecipeDTO> result = await favouriteInterface.GetAllFavouritesOfUserById(userId);
            return result;
        }

        [HttpGet("DetailedFavourite")]
        public async Task<DetailedRecipe> GetDetailedFavouriteOfUserById(int recipeId, int userId)
        {
            DetailedRecipe result = await favouriteInterface.GetDetailedFavouriteOfUserById(recipeId, userId);
            return result;
        }

        [HttpDelete("Favourite")]
        public async Task<ActionResult> DeleteFavourite(int recipeId, int userId)
        {
            bool recipeDeleted = await favouriteInterface.RemoveFavouriteRecipe(recipeId, userId);
            if (recipeDeleted)
            {
                return Ok("Recipe Deleted");
            }
            else
            {
                return BadRequest("Recipe Not Deleted");
            }
        }
    }
}
