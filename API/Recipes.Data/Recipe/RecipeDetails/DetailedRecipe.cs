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

        public int CaloriesAmount { get; set; }

        public int Servings { get; set; }

        public int IngredientCount { get; set; }

        public List<string> Tags { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<string>  Steps { get; set; }

    }
}