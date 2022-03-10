using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FoodApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RecipesController r = new RecipesController();
            r.GetRecipeByIngredients("");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
