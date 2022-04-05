using Microsoft.AspNetCore.Mvc;
using Recipes.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {

        private readonly IRecipe recipeInterface;

        public RecipesController(IRecipe recipeInterface)
        {
            this.recipeInterface = recipeInterface;
        }

        [HttpGet]
        public async Task<List<RecipeDTOResponse>> GetRecipeByIngredients([FromQuery] string[] ingredients)
        {
            List<RecipeDTOResponse> recipes = new();
            recipes = await recipeInterface.GetRecipeByIngredients(ingredients);
            return recipes;
        }
    }
}
