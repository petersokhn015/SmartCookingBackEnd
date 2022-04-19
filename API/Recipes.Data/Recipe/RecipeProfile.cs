using AutoMapper;
namespace Recipes.Data
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDTO>().ReverseMap();
        }
    }
}