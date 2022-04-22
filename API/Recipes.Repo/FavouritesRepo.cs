using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.Extensions.Configuration;
using Recipes.Data;
using Recipes.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;

namespace Recipes.Repo
{
    public class FavouritesRepo : IFavourite
    {
        private readonly IFirebaseConfig _config;
        private readonly IFirebaseClient _client;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public FavouritesRepo(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _config = new FirebaseConfig()
            {
                AuthSecret = _configuration["FirebaseCredentials:Secret"],
                BasePath = _configuration["FirebaseCredentials:BaseUrl"]
            };
            _client = new FireSharp.FirebaseClient(_config);
            _mapper = mapper;

        }

        public async Task<bool> AddFavouriteRecipe(DetailedRecipe detailedRecipe, int userId)
        {
            try
            {
                UserFavourite userFavourite = new();
                userFavourite.DetailedRecipe = new();

                List<DetailedRecipe> favourites = await GetAllDetailedFavouritesOfUserById(userId);

                int favouriteCount = await GetFavouritesCount();
                if(favouriteCount == -1)
                {
                    return false;
                }

                if(favourites != null)
                    favourites.ForEach(favourite => userFavourite.DetailedRecipe.Add(favourite));

                userFavourite.UserId = userId;
                userFavourite.FavouriteId = userId;
                userFavourite.DetailedRecipe.Add(detailedRecipe);
                var setter = _client.Set($"Favourites/UserFavourite{userId}", userFavourite);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<List<RecipeDTO>> GetAllFavouritesOfUserById(int userId)
        {
            try
            {
                var response = await _client.GetAsync($"Favourites/UserFavourite{userId}/DetailedRecipe");
                List<RecipeDTO> data = response.ResultAs<List<RecipeDTO>>();
                return data;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<List<DetailedRecipe>> GetAllDetailedFavouritesOfUserById(int userId)
        {
            try
            {
                var response = await _client.GetAsync($"Favourites/UserFavourite{userId}/DetailedRecipe");
                List<DetailedRecipe> data = response.ResultAs<List<DetailedRecipe>>();
                return data;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<DetailedRecipe> GetDetailedFavouriteOfUserById(long recipeId, int userId)
        {
            try
            {
                var response = await _client.GetAsync($"Favourites/UserFavourite{userId}/DetailedRecipe");
                List<DetailedRecipe> data = response.ResultAs<List<DetailedRecipe>>();

                return data.Where(recipe => recipe.Id == recipeId).Single();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
          
        }

        public async Task<int> GetFavouritesCount()
        {
            try
            {
                var result = await _client.GetAsync("Favourites");
                Dictionary<string, UserFavourite> data = result.ResultAs<Dictionary<string, UserFavourite>>();

                return _ = data == null ? 0 : data.Count;

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return -1;
            }

        }

        public async Task<bool> RemoveFavouriteRecipe(int recipeId, int userId)
        {
            try
            {
                var response = await _client.GetAsync($"Favourites/UserFavourite{userId}/DetailedRecipe");
                List<DetailedRecipe> data = response.ResultAs<List<DetailedRecipe>>();
                var itemToRemove =  data.Where(recipe => recipe.Id == recipeId).Single();
                data.Remove(itemToRemove);
                var result = await _client.SetAsync($"Favourites/UserFavourite{userId}/DetailedRecipe", data);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
