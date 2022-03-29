using AutoMapper;

namespace Recipes.Data
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<RecipeDTORequest, RecipeDTOResponse>().ReverseMap();
        }
        
    }
}
