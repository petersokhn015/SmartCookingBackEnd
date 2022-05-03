using AutoMapper;
using FireSharp.Config;
using Microsoft.Extensions.Configuration;
using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recipes.Repo
{
    public class RecipesRepo : IRecipe
    {
        HttpClient _client;
        private readonly IConfiguration _configuration;
        readonly string baseURL, apiKey;
        private readonly IMapper _mapper;

        public RecipesRepo(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            baseURL = _configuration.GetValue<string>("SpoonacularCredentials:BaseUrl");
            apiKey = _configuration.GetValue<string>("SpoonacularCredentials:Secret");
            _client = new HttpClient();
            _mapper = mapper;
        }



        public async Task<List<RecipeDTO>> GetRecipeByIngredients(string[] ingredients)
        {
            List<RecipeDTO> results = new();

            try
            {
                string ingredientsString = String.Join(",", ingredients);
                var response = await _client.GetAsync(new Uri($"{baseURL}findByIngredients?apiKey={apiKey}&ingredients={ingredientsString}"));

                if (response.IsSuccessStatusCode) results = await response.Content.ReadAsAsync<List<RecipeDTO>>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            return results;
        }

        public async Task<DetailedRecipe> GetRecipeInfo(int recipeId)
        {
            AnalysedRecipe recipe = new();

            try
            {
                var recipeResponse = await _client.GetAsync(new Uri($"{baseURL}{recipeId}/information?apiKey={apiKey}&includeNutrition=true"));
                if (recipeResponse.IsSuccessStatusCode) recipe = await recipeResponse.Content.ReadAsAsync<AnalysedRecipe>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return _mapper.Map<DetailedRecipe>(recipe);

        }

        public async Task<List<RecipeDTO>> GetRecipesByFilter(Filter filter)
        {
            FilterRecipe results = new();
            string cuisineType, intolerance;
            try
            {
                string apiUrl = $"{baseURL}complexSearch?apiKey={apiKey}&query={filter.Query.ToLower()}";

                if (filter.CuisineTypes != null || filter.CuisineTypes.Count != 0) { cuisineType = String.Join(",+", filter.CuisineTypes); apiUrl += $"&cuisine={cuisineType.ToLower()}"; }
                if (filter.Intolerances != null || filter.Intolerances.Count != 0) { intolerance = String.Join(",+", filter.Intolerances); apiUrl += $"&intolerances={intolerance.ToLower()}"; }
                if (filter.Diet != null || filter.Diet != "") { apiUrl += $"&diet={filter.Diet}"; }
                if (filter.MealType != null || filter.MealType != "") { apiUrl += $"&type={filter.MealType}"; }
                if (filter.MaxCookTime > 0) { apiUrl += $"&maxReadyTime={filter.MaxCookTime}"; }

                var response = await _client.GetAsync(new Uri(apiUrl));
                if (response.IsSuccessStatusCode) results = await response.Content.ReadAsAsync<FilterRecipe>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return results.Results;
        }


        public async Task<List<RecipeDTO>> GetRecommendedRecipes(int[] recipeIds)
        {
            Random random = new Random();
            List<RecipeDTO> returnedRecipes = new();
            List<RecipeDTO> allRecipes = new();

            try
            {
                for (int i = 0; i < recipeIds.Length; i++)
                {
                    List<RecipeDTO> temp = new();
                    temp = await GetRecommendedRecipe(recipeIds[i]);
                    temp.ForEach((recipe) => allRecipes.Add(recipe));
                }

                for (int i = 0; i < 3; i++)
                {
                    int j = random.Next(allRecipes.Count + 1);
                    returnedRecipes.Add(await GetRecipeById(allRecipes[j].Id));
                    allRecipes.RemoveAt(j);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return returnedRecipes;

        }

        public async Task<List<RecipeDTO>> GetRecommendedRecipe(int recipeId)
        {
            List<RecipeDTO> returnedResults = new();
            Random random = new();
            try
            {
                var response = await _client.GetAsync(new Uri($"{baseURL}{recipeId}/similar?apiKey={apiKey}"));
                if (response.IsSuccessStatusCode)
                {
                    List<Recipe> results = await response.Content.ReadAsAsync<List<Recipe>>();
                    results.ForEach(recipe => returnedResults.Add(_mapper.Map<RecipeDTO>(recipe)));

                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return returnedResults;
        }

        public async Task<List<RecipeDTO>> GetRandomRecipes()
        {
            RandomRecipe results = new();
            try
            {
                var response = await _client.GetAsync(new Uri($"{baseURL}random?apiKey={apiKey}&number=3"));
                if (response.IsSuccessStatusCode) results = await response.Content.ReadAsAsync<RandomRecipe>();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return results.Recipes;
        }

        public async Task<List<RecipeDTO>> GetRecipeByTime(string tag)
        {
            RandomRecipe results = new();
            try
            {
                var response = await _client.GetAsync(new Uri($"{baseURL}random?apiKey={apiKey}&tags={tag}&number=5"));
                if (response.IsSuccessStatusCode) results = await response.Content.ReadAsAsync<RandomRecipe>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return results.Recipes;
        }

        public async Task<RecipeDTO> GetRecipeById(long id)
        {
            RecipeDTO result = new();
            try
            {
                var response = await _client.GetAsync(new Uri($"{baseURL}/{id}/information?apiKey={apiKey}"));
                if (response.IsSuccessStatusCode) result = await response.Content.ReadAsAsync<RecipeDTO>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }
    }
}