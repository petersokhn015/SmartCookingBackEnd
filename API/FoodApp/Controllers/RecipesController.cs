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

        [HttpGet("RecipeByIngredient")]
        public async Task<List<RecipeDTO>> GetRecipeByIngredients([FromQuery] string[] ingredients)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecipeByIngredients(ingredients);
            return recipes;
        }

        [HttpGet("RecipeByFilter")]
        public async Task<List<RecipeDTO>> GetRecipeByFilter([FromQuery] Filter filter)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecipesByFilter(filter);
            return recipes;
        }

        [HttpGet("RandomRecipes")]
        public async Task<List<RecipeDTO>> GetRandomRecipe()
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRandomRecipes();
            return recipes;
        }

        [HttpGet("RecommendedRecipe")]
        public async Task<List<RecipeDTO>> GetRecommendedRecipe([FromQuery] int id)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecommendedRecipes(id);
            return recipes;
        }
    }
}
