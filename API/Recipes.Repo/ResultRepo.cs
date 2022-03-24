﻿using Recipes.Data;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Repo
{
    public class PoRepo : IPo
    {
        public async Task<Po> GetResult(string[] ingredients)
        {
            HttpClient client = new HttpClient();

            Po Po = new Po();

            string ingredientString = String.Join(" ", ingredients);

            HttpResponseMessage response = await client.GetAsync("https://api.edamam.com/api/recipes/v2?q="+ ingredientString + "&app_key=cb9146dd569b6c3f77ee56a410930f11&type=public&app_id=3c9ba749&field=label&field=images&field=ingredients&field=calories&field=cuisineType&field=mealType&field=dishType&field=dietLabels&field=healthLabels");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                Po = Serialize.FromJson(data);
                return Po;
            }

            return null;
        }
    }
}
