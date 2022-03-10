using Newtonsoft.Json;

namespace Recipes.Data
{
    public class Ingredient
    {
        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("measure")]
        public string Measure { get; set; }

        [JsonProperty("food")]
        public string Food { get; set; }
    }
}
