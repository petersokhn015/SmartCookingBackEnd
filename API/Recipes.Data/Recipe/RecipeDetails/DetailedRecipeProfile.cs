using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Data
{
    public class DetailedRecipeProfile : Profile
    {
        public DetailedRecipeProfile()
        {
            CreateMap<AnalysedRecipe, DetailedRecipe>().ReverseMap();
        }
    }
}