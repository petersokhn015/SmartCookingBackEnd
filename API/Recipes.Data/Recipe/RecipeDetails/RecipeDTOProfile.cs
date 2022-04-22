using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Data
{
    public class RecipeDTOProfile : Profile
    {
        public RecipeDTOProfile()
        {
            CreateMap<DetailedRecipe, List<RecipeDTO>>().ReverseMap();
        }
    }
}