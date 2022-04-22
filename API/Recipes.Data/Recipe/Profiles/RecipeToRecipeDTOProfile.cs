using AutoMapper;
namespace Recipes.Data
{
    public class RecipeToRecipeDTOProfile : Profile
    {
        public RecipeToRecipeDTOProfile()
        {
            CreateMap<Recipe, RecipeDTO>().ReverseMap();
        }
    }
}