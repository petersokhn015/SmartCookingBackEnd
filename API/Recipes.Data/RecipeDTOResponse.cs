using Recipes.Data;
using System;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class RecipeDTOResponse
    {
        public long Id { get; set; }

        public Uri Image { get; set; }

        public string Title { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
}


