using Newtonsoft.Json;
using System.Collections.Generic;
namespace Recipes.Data
{
    public partial class FilterRecipe
    {
        [JsonProperty("results")]
        public List<RecipeDTO> Results { get; set; }
    }
}