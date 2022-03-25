using Newtonsoft.Json;
using System.Collections.Generic;

namespace Recipes.Data
{
    public static class Serialize
    {
        public static Recipe FromJson(string json) => JsonConvert.DeserializeObject<Recipe>(json, Recipes.Data.Converter.Settings); 
        public static string ToJson(this Recipe self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);

        public static List<RecipeDTO> RecipeToRecipeDTO(Recipe recipe)
        {
            List<RecipeDTO> recipes = new();

            recipe.Hits.ForEach(hit => recipes.Add(new RecipeDTO(hit.Recipe.Label, hit.Recipe.Images.Thumbnail, hit.Recipe.Ingredients, hit.Recipe.DietLabels, hit.Recipe.HealthLabels, hit.Recipe.Calories,
                                       hit.Recipe.CuisineType, hit.Recipe.MealType, hit.Recipe.DietLabels)));

            return recipes;

        }
    }
}