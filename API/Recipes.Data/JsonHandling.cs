using Newtonsoft.Json;
using System.Collections.Generic;

namespace Recipes.Data
{
    public static class JsonHandling
    {
        public static List<RecipeDTORequest> FromJson(string json) => JsonConvert.DeserializeObject<List<RecipeDTORequest>>(json, Recipes.Data.Converter.Settings);
        public static string ToJson(this List<RecipeDTORequest> self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);
    }
}
