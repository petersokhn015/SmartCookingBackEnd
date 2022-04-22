using System.Collections.Generic;

namespace Recipes.Data
{
    public class UserFavourite
    {
        public int FavouriteId { get; set; }
        public int UserId { get; set; }
        public List<DetailedRecipe> DetailedRecipe { get; set; }
    }
}
