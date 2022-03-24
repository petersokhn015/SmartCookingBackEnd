using Newtonsoft.Json;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class Po
    {
        [JsonProperty("hits")]
        public List<Hit> Hits { get; set; }
    }
}
