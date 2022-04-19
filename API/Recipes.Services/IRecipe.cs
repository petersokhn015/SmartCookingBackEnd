using Recipes.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRecipe
{
    Task<List<RecipeDTO>> GetRecipeByIngredients(string[] ingredients);

    Task<List<RecipeDTO>> GetRecommendedRecipes(int recipeId);

    Task<DetailedRecipe> GetRecipeInfo(int recipeId);

    Task<List<RecipeDTO>> GetRecipesByFilter(Filter filter);

    Task<List<RecipeDTO>> GetRandomRecipes();

}