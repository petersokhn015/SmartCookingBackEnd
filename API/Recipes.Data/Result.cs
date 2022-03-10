using Newtonsoft.Json;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class Result
    {
        [JsonProperty("hits")]
        public List<Hit> Hits { get; set; }
    }
}
