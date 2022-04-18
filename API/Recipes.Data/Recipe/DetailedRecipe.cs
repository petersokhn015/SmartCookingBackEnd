using System;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class DetailedRecipe
    {
        public long Id { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public int CookTime { get; set; }

        public int CaloriesCount { get; set; }

        public int IngredientCount { get; set; }

        public String Tags { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<String>  Steps { get; set; }

    }
}