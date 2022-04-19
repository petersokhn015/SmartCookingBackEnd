using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class RecipeDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
