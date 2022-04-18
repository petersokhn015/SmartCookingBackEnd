using AutoMapper;
using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recipes.Repo
{
    public class RecipeRepo : IRecipe
    {
        HttpClient client = new();
        //private readonly IMapper _mapper;
        //public RecipeRepo(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}

        string baseURL = "https://api.spoonacular.com/recipes/";
        
        public async Task<List<Recipe>> GetRecipeByIngredients(string[] ingredients)
        {
            List<Recipe> results = new();
            
            try
            {
                string ingredientsString = String.Join(",+", ingredients);
                var response = await client.GetAsync(new Uri(baseURL + "findByIngredients?apiKey=03f7fd19fd3e438cb751fa3523af01e0&ingredients=" + ingredients));

                if (response.IsSuccessStatusCode) results = await response.Content.ReadAsAsync<List<Recipe>>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            return results;
        }

        public Task<DetailedRecipe> GetRecipeInfo(int recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Result>> GetRecipesByFilter(Filter filter)
        {
            FilterRecipe results = new();
            string cuisineType, intolerance;
            try 
            {
                string apiUrl = baseURL + "complexSearch?apiKey=03f7fd19fd3e438cb751fa3523af01e0&query=" + filter.Query.ToLower();

                if (filter.CuisineTypes != null) { cuisineType = String.Join(",+", filter.CuisineTypes); apiUrl += $"&cuisine={cuisineType.ToLower()}"; }
                if (filter.Intolerances != null) { intolerance = String.Join(",+", filter.Intolerances); apiUrl += $"&intolerances={intolerance.ToLower()}"; }
                if (filter.Diet != null) { apiUrl += $"&diet{filter.Diet}"; }
                if (filter.MealType != null) { apiUrl += $"&type{filter.MealType}"; }
                if (filter.MaxCookTime > 0 ) { apiUrl += $"&maxReadyTime{filter.MaxCookTime}"; }

                var response = await client.GetAsync(new Uri(apiUrl));
                if (response.IsSuccessStatusCode) results = await response.Content.ReadAsAsync<FilterRecipe>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return results.Results;
        }

        public Task<List<Recipe>> GetRecommendedRecipes(int recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recipe>> GetRandomRecipes()
        {
           
            List<Recipe> results = new();
            try
            {
                var response = await client.GetAsync(new Uri("https://api.spoonacular.com/recipes/random?apiKey=03f7fd19fd3e438cb751fa3523af01e0&number=5"));
                if (response.IsSuccessStatusCode) results = await response.Content.ReadAsAsync<List<Recipe>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return results;
        }
    }
}
