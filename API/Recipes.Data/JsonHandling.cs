using Newtonsoft.Json;
using Recipes.Data;
using System.Collections.Generic;
namespace Recipes.Data
{
    public static class JsonHandling
    {
        public static List<RecipeDTO> RecipeFromJson(string json) => JsonConvert.DeserializeObject<List<RecipeDTO>>(json, Recipes.Data.Converter.Settings);
        public static string RecipeToJson(this List<RecipeDTO> self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);
        public static List<FilterRecipe> FilterRecipeFromJson(string json) => JsonConvert.DeserializeObject<List<FilterRecipe>>(json, Recipes.Data.Converter.Settings);
        public static string FilterRecipeToJson(this FilterRecipe self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);
        public static AnalysedRecipe AnalysedRecipeFromJson(string json) => JsonConvert.DeserializeObject<AnalysedRecipe>(json, Recipes.Data.Converter.Settings);
        public static string AnalysedRecipeToJson(this AnalysedRecipe self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);

    }
}