using Microsoft.AspNetCore.Mvc;
using Recipes.Data;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        public async Task<List<RecipeDTO>> GetRecipeByIngredients([FromQuery]string[] ingredients)
        {
            List<RecipeDTO> recipes = await recipeInterface.GetResult(ingredients);
            return recipes;
        }
    }
}
