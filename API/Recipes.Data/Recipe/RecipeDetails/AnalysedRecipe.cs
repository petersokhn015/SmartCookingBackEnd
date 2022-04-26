using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Data
{
    public class AnalysedRecipe
    {

        [JsonProperty("extendedIngredients")]
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("readyInMinutes")]
        public long CookTime { get; set; }

        [JsonProperty("servings")]
        public long Servings { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("nutrition")]
        public Nutrition Nutrition { get; set; }

        [JsonProperty("cuisines")]
        public List<string> Cuisines { get; set; }

        [JsonProperty("dishTypes")]
        public List<string> DishTypes { get; set; }

        [JsonProperty("diets")]
        public List<string> Diets { get; set; }

        [JsonProperty("analyzedInstructions")]
        public List<Instruction> AnalyzedInstructions { get; set; }

        public int CaloriesCount { get { return GetCalories(); } }

        public List<Ingredient> Ingredients { get { return ConvertIngredients(); } }

        public List<string> Tags { get { return FillTagsList(); } }

        public int IngredientCount { get { return ExtendedIngredients.Count; } }
 
        public List<string> Steps { get { return ConsertInstructions(); } }

        int GetCalories()
        {
            return Nutrition.Nutrients.Where(e => e.Name.Equals("Calories")).Select(e => (int)e.Amount).ToList().First();
        }

        List<string> ConsertInstructions()
        {
            List<string> steps = new();
            AnalyzedInstructions.ForEach(e => e.Steps.ForEach(s => steps.Add( s.StepString)));
            return steps;
        }

        List<Ingredient> ConvertIngredients()
        {
            List<Ingredient> ingredients = new();
            ExtendedIngredients.ForEach(e => ingredients.Add(new Ingredient(e.Image,
                                                                            e.Measures.MesureDetails.Amount,
                                                                            e.Name,
                                                                            e.Measures.MesureDetails.Unit)));
            return ingredients;
        }

        List<string> FillTagsList()
        {
            List<string> tags = new();

            if (Cuisines != null) Cuisines.ForEach(cuisine => tags.Add(cuisine));
            if (Diets != null) Diets.ForEach(diet => tags.Add(diet));

            return tags;
        }

    }
}
