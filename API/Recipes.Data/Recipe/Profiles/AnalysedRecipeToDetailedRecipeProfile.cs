using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Data
{
    public class AnalysedRecipeToDetailedRecipeProfile : Profile
    {
        public AnalysedRecipeToDetailedRecipeProfile()
        {
            CreateMap<AnalysedRecipe, DetailedRecipe>().ReverseMap();
        }
    }
}