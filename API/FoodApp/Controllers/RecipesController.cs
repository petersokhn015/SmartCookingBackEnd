using Microsoft.AspNetCore.Mvc;
using Recipes.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        string baseUrl = "https://api.edamam.com/api/recipes/v2";
        string rest = "&app_key=cb9146dd569b6c3f77ee56a410930f11&type=public&app_id=3c9ba749&field=label&field=images&field=ingredients&field=calories&field=totalTime&field=cuisineType&field=mealType&field=dishType&field=dietLabels&field=healthLabels";

        [HttpGet]
        public async Task<Result> GetRecipeByIngredients(string ingredients)
        {
            HttpClient client = new HttpClient();

            Result result = new Result();

            string path = baseUrl + "?q=" + ingredients + rest;

            HttpResponseMessage response = await client.GetAsync("https://api.edamam.com/api/recipes/v2?q=eggs mayo&app_key=cb9146dd569b6c3f77ee56a410930f11&type=public&app_id=3c9ba749&field=label&field=images&field=ingredients&field=calories&field=cuisineType&field=mealType&field=dishType&field=dietLabels&field=healthLabels");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                result = Serialize.FromJson(data);
                return result;
            }

            return null;
        }
    }
}
