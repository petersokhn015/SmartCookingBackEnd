using Newtonsoft.Json;

namespace Recipes.Data
{
    public static class Serialize
    {
        public static Result FromJson(string json) => JsonConvert.DeserializeObject<Result>(json, Recipes.Data.Converter.Settings); 
        public static string ToJson(this Result self) => JsonConvert.SerializeObject(self, Recipes.Data.Converter.Settings);
    }
}