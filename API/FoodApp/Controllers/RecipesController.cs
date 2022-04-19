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
        public async Task<List<Recipe>> GetRecipeByIngredients([FromQuery] string[] ingredients)
        {
            List<Recipe> recipes = await recipeInterface.GetRecipeByIngredients(ingredients);
            return recipes;
        }

        [HttpGet("RecipeByFilter")]
        public async Task<List<Recipe>> GetRecipeByFilter([FromQuery] Filter filter)
        {
            List<Recipe> recipes = await recipeInterface.GetRecipesByFilter(filter);
            return recipes;
        }

        [HttpGet("RandomRecipes")]
        public async Task<List<Recipe>> GetRandomRecipe()
        {
            List<Recipe> recipes = await recipeInterface.GetRandomRecipes();
            return recipes;
        }

        [HttpGet("RecommendedRecipe")]
        public async Task<List<RecommendedRecipe>> GetRecommendedRecipe([FromQuery] int id)
        {
            List<RecommendedRecipe> recipes = await recipeInterface.GetRecommendedRecipes(id);
            return recipes;
        }
    }
}
