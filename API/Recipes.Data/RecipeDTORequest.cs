using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class RecipeDTORequest
    {
        public long Id { get; set; }

        public Uri Image { get; set; }

        public string Title { get; set; }

        public List<Ingredient> MissedIngredients { get; set; }

        public List<Ingredient> UnusedIngredients { get; set; }

        public List<Ingredient> UsedIngredients { get; set; }

        public List<Ingredient> Ingredients
        {
            get
            {
                var list = new List<Ingredient>();
                MissedIngredients.ForEach(i => list.Add(i));
                UsedIngredients.ForEach(i => list.Add(i));
                UnusedIngredients.ForEach(i => list.Add(i));
                return list;
            }
            }
        }
}
