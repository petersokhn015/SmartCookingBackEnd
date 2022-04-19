using Recipes.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRecipe
{
    Task<List<Recipe>> GetRecipeByIngredients(string[] ingredients);

    Task<List<RecommendedRecipe>> GetRecommendedRecipes(int recipeId);

    Task<DetailedRecipe> GetRecipeInfo(int recipeId);

    Task<List<Recipe>> GetRecipesByFilter(Filter filter);

    Task<List<Recipe>> GetRandomRecipes();

}