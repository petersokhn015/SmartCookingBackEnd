using Recipes.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

    public interface IRecipe
    {
        Task<List<RecipeDTO>> GetRecipeByIngredients(string[] ingredients);

        Task<List<RecipeDTO>> GetRecommendedRecipe(int recipeId);

        Task<List<RecipeDTO>> GetRecommendedRecipes(int[] recipeIds);

        Task<DetailedRecipe> GetRecipeInfo(int recipeId);

        Task<List<RecipeDTO>> GetRecipesByFilter(Filter filter);

        Task<List<RecipeDTO>> GetRandomRecipes();

        Task<List<RecipeDTO>> GetRecipeByTime(string tag);
        
        Task<RecipeDTO> GetRecipeById(long id);
    }
