using Recipes.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRecipe
{
    Task<List<RecipeDTOResponse>> GetRecipeByIngredients(string[] ingredients);
}