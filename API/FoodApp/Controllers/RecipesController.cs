using Microsoft.AspNetCore.Mvc;
using Recipes.Data;
using System;
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

        [HttpPost("RecipeByIngredient")]
        public async Task<ActionResult> GetRecipeByIngredients([FromBody] string[] ingredients)
        {
            Console.WriteLine(ingredients);
            List<RecipeDTO> recipes = await recipeInterface.GetRecipeByIngredients(ingredients);
            if(recipes != null)
            {
                return Ok(recipes);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("RecipeByFilter")]
        public async Task<ActionResult> GetRecipeByFilter([FromBody] Filter filter)
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

        [HttpGet("RecommendedRecipe")]
        public async Task<ActionResult> GetRecommendedRecipe([FromQuery] int id)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecommendedRecipes(id);
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
        public async Task<ActionResult> GetRecipeInfo([FromQuery] int recipeId)
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
        public async Task<ActionResult> GetRecipeByTime()
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecipeByTime();
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
