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
            HttpClient client = new HttpClient();
            Recipe recipe;
            string ingredientString = String.Join(" ", ingredients);
            var response = await client.GetAsync("https://api.edamam.com/api/recipes/v2?q=" + ingredientString + "&app_key=cb9146dd569b6c3f77ee56a410930f11&type=public&app_id=3c9ba749&field=label&field=images&field=ingredients&field=calories&field=cuisineType&field=mealType&field=dishType&field=dietLabels&field=healthLabels");
            if (response.IsSuccessStatusCode)
            {
                recipe = await response.Content.ReadAsAsync<Recipe>();
               
                return Serialize.RecipeToRecipeDTO(recipe);
            }
            return null;
        }
    }
}
