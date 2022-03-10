using Newtonsoft.Json;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class RecipeClass
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("dietLabels")]
        public List<string> DietLabels { get; set; }

        [JsonProperty("healthLabels")]
        public List<string> HealthLabels { get; set; }

        [JsonProperty("ingredients")]
        public List<Ingredient> Ingredients { get; set; }

        [JsonProperty("calories")]
        public long Calories { get; set; }

        [JsonProperty("cuisineType")]
        public List<string> CuisineType { get; set; }

        [JsonProperty("mealType")]
        public List<string> MealType { get; set; }

        [JsonProperty("dishType")]
        public List<string> DishType { get; set; }
    }
}