using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class Nutrient
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
