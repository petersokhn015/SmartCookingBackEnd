using Newtonsoft.Json;
using Recipes.Data;
using System.Collections.Generic;
namespace Recipes.Data
{
    public static class JsonHandling
    {
        public static List<RecipeDTO> RecipeFromJson(string json) => JsonConvert.DeserializeObject<List<RecipeDTO>>(json, Recipes.Data.Converter.Settings);
        public static string RecipeToJson(this List<RecipeDTO> self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);
        public static List<Filter> FilterFromJson(string json) => JsonConvert.DeserializeObject<List<Filter>>(json, Recipes.Data.Converter.Settings);
        public static string FilterToJson(this Filter self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);
        public static AnalysedRecipe AnalysedRecipeFromJson(string json) => JsonConvert.DeserializeObject<AnalysedRecipe>(json, Recipes.Data.Converter.Settings);
        public static string AnalysedRecipeToJson(this AnalysedRecipe self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);
        public static DetailedRecipe DetailedRecipeFromJson(string json) => JsonConvert.DeserializeObject<DetailedRecipe>(json, Recipes.Data.Converter.Settings);
    }
}