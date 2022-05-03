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
        public async Task<ActionResult> GetRecipeByIngredients([FromQuery] string[] ingredients)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecipeByIngredients(ingredients);
            if (recipes != null)
            {
                return Ok(recipes);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("RecipeByFilter")]
        public async Task<ActionResult> GetRecipeByFilter([FromQuery] Filter filter)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecipesByFilter(filter);
            if (recipes != null)
            {
                return Ok(recipes);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("RandomRecipes")]
        public async Task<ActionResult> GetRandomRecipe()
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRandomRecipes();
            if (recipes != null)
            {
                return Ok(recipes);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("RecommendedRecipe")]
        public async Task<ActionResult> GetRecommendedRecipes([FromBody] int[] ids)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecommendedRecipes(ids);
            if (recipes != null)
            {
                return Ok(recipes);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("RecipeDetails")]
        public async Task<ActionResult> GetRecipeInfo(int recipeId)
        {
            DetailedRecipe recipe = await recipeInterface.GetRecipeInfo(recipeId);
            if (recipe != null)
            {
                return Ok(recipe);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("RecipeByTime")]
        public async Task<ActionResult> GetRecipeByTime([FromQuery] string tag)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecipeByTime(tag);
            if (recipes != null)
            {
                return Ok(recipes);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
