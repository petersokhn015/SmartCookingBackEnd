using Recipes.Data;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recipes.Repo
{
    public class RecipeRepo : IRecipe
    {
        public async Task<List<RecipeDTO>> GetResult(string[] ingredients)
        {
            try
            {
                HttpClient client = new HttpClient();

                Recipe recipe = new Recipe();

                string ingredientString = String.Join(" ", ingredients);

                HttpResponseMessage response = await client.GetAsync("https://api.edamam.com/api/recipes/v2?q=" + ingredientString + "&app_key=cb9146dd569b6c3f77ee56a410930f11&type=public&app_id=3c9ba749&field=label&field=images&field=ingredients&field=calories&field=cuisineType&field=mealType&field=dishType&field=dietLabels&field=healthLabels&random=true");

                var data = await response.Content.ReadAsStringAsync();
                recipe = Serialize.FromJson(data);
                return Serialize.RecipeToRecipeDTO(recipe);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }      
        }
    }
}
