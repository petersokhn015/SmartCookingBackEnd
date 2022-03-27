using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IRecipe
    {
        Task<List<RecipeDTO>> GetResult(string[] ingredients);
    }
}
