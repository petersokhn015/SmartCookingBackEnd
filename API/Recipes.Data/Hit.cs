using Newtonsoft.Json;

namespace Recipes.Data
{
    public class Hit
    {
        [JsonProperty("recipe")]
        public RecipeClass Recipe { get; set; }

    }
}
