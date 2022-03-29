using AutoMapper;
using Recipes.Data;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recipes.Repo
{
    public class RecipeRepo : IRecipe
    {
        private readonly IMapper _mapper;
        public RecipeRepo(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<RecipeDTOResponse>> GetRecipeByIngredients(string[] ingredients)
        {
            List<RecipeDTOResponse> results = new();
            HttpClient client = new();
            try
            {
                string ingredientsString = String.Join(",+", ingredients);
                var response = await client.GetAsync("https://api.spoonacular.com/recipes/findByIngredients?apiKey=03f7fd19fd3e438cb751fa3523af01e0&ingredients=" + ingredients);

                if (response.IsSuccessStatusCode)
                {
                    var recipes = await response.Content.ReadAsAsync<List<RecipeDTORequest>>();

                    foreach (var recipe in recipes)
                    {
                        results.Add(_mapper.Map<RecipeDTOResponse>(recipe));
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            return results;
        }
    }
}
