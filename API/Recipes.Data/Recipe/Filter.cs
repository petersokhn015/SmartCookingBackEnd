using System;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class Filter
    {
        public string Query { get; set; }
            
        public string? MealType { get; set; }

        public string? Diet { get; set; }

        public List<string>? Intolerances { get; set; }

        public List<string>? CuisineTypes { get; set; }

        public int? MaxCookTime { get; set; }

    }
}
