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
        public async Task<List<RecipeDTO>> GetRecipeByIngredients([FromBody] string[] ingredients)
        {
            Console.WriteLine(ingredients);
            List<RecipeDTO> recipes = await recipeInterface.GetRecipeByIngredients(ingredients);
            return recipes;
        }

        [HttpPost("RecipeByFilter")]
        public async Task<List<RecipeDTO>> GetRecipeByFilter([FromBody] Filter filter)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecipesByFilter(filter);
            return recipes;
        }

        [HttpGet("RandomRecipes")]
        public async Task<List<RecipeDTO>> GetRandomRecipe([FromQuery]int recipeCount)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRandomRecipes(recipeCount);
            return recipes;
        }

        [HttpGet("RecommendedRecipe")]
        public async Task<List<RecipeDTO>> GetRecommendedRecipe([FromQuery] int id)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetRecommendedRecipes(id);
            return recipes;
        }

        [HttpGet("RecipeDetails")]
        public async Task<DetailedRecipe> GetRecipeInfo([FromQuery] int recipeId)
        {
            DetailedRecipe recipe = await recipeInterface.GetRecipeInfo(recipeId);
            return recipe;
        }
    }
}
