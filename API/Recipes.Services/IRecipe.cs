using Recipes.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRecipe
{
    Task<List<Recipe>> GetRecipeByIngredients(string[] ingredients);

    Task<List<Recipe>> GetRecommendedRecipes(int recipeId);

    Task<DetailedRecipe> GetRecipeInfo(int recipeId);

    Task<List<Result>> GetRecipesByFilter(Filter filter);

    Task<List<Recipe>> GetRandomRecipes();

}