using Newtonsoft.Json;
using System.Collections.Generic;

namespace Recipes.Data
{
    public static class Serialize
    {
        public static Po FromJson(string json) => JsonConvert.DeserializeObject<Po>(json, Recipes.Data.Converter.Settings); 
        public static string ToJson(this Po self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);

        public static List<Recipe> PoToRecipe(Po Po)
        {
            List<Recipe> recipes = new();

            Po.Hits.ForEach(hit => recipes.Add(new Recipe(hit.Recipe.Label, hit.Recipe.Images.Thumbnail, hit.Recipe.Ingredients, hit.Recipe.DietLabels, hit.Recipe.HealthLabels, hit.Recipe.Calories,
                                       hit.Recipe.CuisineType, hit.Recipe.MealType, hit.Recipe.DietLabels)));

            return recipes;

        }
    }
}