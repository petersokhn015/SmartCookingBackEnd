using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Data
{
    public class DetailedRecipeToRecipeDTOProfile : Profile
    {
        public DetailedRecipeToRecipeDTOProfile()
        {
            CreateMap<DetailedRecipe, RecipeDTO>().ReverseMap();
        }
    }
}