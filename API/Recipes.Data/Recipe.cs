using Newtonsoft.Json;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class Recipe
    {
        [JsonProperty("hits")]
        public List<Hit> Hits { get; set; }
    }
}
