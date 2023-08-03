using ServiceAgent.Spoonacular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using ServiceAgent.Spoonacular.REntities;


namespace ServiceAgent
{
    internal class TestServiceAgent
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //var services = new ServiceCollection();
            //Applications application = new Applications(services);
            //var _spoonacular = application.Services.GetRequiredService<ISpoonacularService>();
            ISpoonacularService _spoonacular = new SpoonacularService();
            testFreeSearch(_spoonacular);
            testSearchByID(_spoonacular);
            testSearchByIngridient(_spoonacular);
        }

        private static void testFreeSearch(ISpoonacularService _spoonacular)
        {
            var recipes = _spoonacular.GetRecipiesByFreeSearch("SOUP").GetAwaiter().GetResult();

            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine($"id: {recipe.ID} title: {recipe.Title} image: {recipe.Image}");
            }
        }

        private static void testSearchByIngridient(ISpoonacularService _spoonacular)
        {
            List<Ingridient> ingridients = new List<Ingridient>() { new Ingridient() { Name = "egg" }, new Ingridient() { Name = "banana" } };
            var recipes = _spoonacular.GetRecipiesByIngridients(ingridients).GetAwaiter().GetResult();

            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine($"id: {recipe.ID} title: {recipe.Title} image: {recipe.Image}");
            }
        }

        private static void testSearchByID(ISpoonacularService _spoonacular)
        {
            var specificRecipe = _spoonacular.getRecipeById(716429).GetAwaiter().GetResult();
            Console.WriteLine($"id: {specificRecipe.ID} title: {specificRecipe.Title} image: {specificRecipe.Image}");
        }

        
    }
}
