﻿using AutoMapper;
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
                string ingredientsString = String.Join(",+", ingredients);
                var response = await _client.GetAsync(new Uri($"{baseURL}findByIngredients?apiKey={apiKey}&ingredients={ingredients}"));

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

                if (filter.CuisineTypes != null) { cuisineType = String.Join(",+", filter.CuisineTypes); apiUrl += $"&cuisine={cuisineType.ToLower()}"; }
                if (filter.Intolerances != null) { intolerance = String.Join(",+", filter.Intolerances); apiUrl += $"&intolerances={intolerance.ToLower()}"; }
                if (filter.Diet != null) { apiUrl += $"&diet={filter.Diet}"; }
                if (filter.MealType != null) { apiUrl += $"&type={filter.MealType}"; }
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

        public async Task<List<RecipeDTO>> GetRecommendedRecipes(int recipeId)
        {
            List<RecipeDTO> returnedResults = new();
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
    }
}