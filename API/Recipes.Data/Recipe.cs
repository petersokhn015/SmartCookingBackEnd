﻿using System.Collections.Generic;

namespace Recipes.Data
{
    public class Recipe
    {
        public Recipe(string label, Image image, List<Ingredient> ingredient, List<string> dietLabels, List<string> healthLabels, long calories, List<string> cuisineType, List<string> mealType, List<string> dishType)
        {
            Label = label;
            Image = image;
            Ingredient = ingredient;
            DietLabels = dietLabels;
            HealthLabels = healthLabels;
            Calories = calories;
            CuisineType = cuisineType;
            MealType = mealType;
            DishType = dishType;
        }

        public string Label { get; set; }

        public Image Image { get; set; }

        public List<Ingredient> Ingredient { get; set; }

        public List<string> DietLabels { get; set; }

        public List<string> HealthLabels { get; set; }

        public long Calories { get; set; }

        public List<string> CuisineType { get; set; }

        public List<string> MealType { get; set; }

        public List<string> DishType { get; set; }

        public List<Recipe> ResultToRecipe(Result result)
        {
            List<Recipe> recipes = new();

            result.Hits.ForEach(hit => recipes.Add(new Recipe(hit.Recipe.Label, hit.Recipe.Images.Thumbnail, hit.Recipe.Ingredients, hit.Recipe.DietLabels, hit.Recipe.HealthLabels, hit.Recipe.Calories,
                                       hit.Recipe.CuisineType, hit.Recipe.MealType, hit.Recipe.DietLabels)));

            return recipes;

        }
    }
}
