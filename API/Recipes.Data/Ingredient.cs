using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class Ingredient
    {
        public long Id { get; set; }

        public double Amount { get; set; }

        public string Name { get; set; }

        [JsonProperty("original")]
        public string Preparation { get; set; }

        public string Unit { get; set; }
    }
}
