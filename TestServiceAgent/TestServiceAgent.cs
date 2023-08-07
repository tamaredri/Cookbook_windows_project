﻿using ServiceAgent.Spoonacular;
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

            Console.WriteLine("-------------------------------------------------------------------------");
            //testSearchByID(_spoonacular);

            Console.WriteLine("-------------------------------------------------------------------------");
            //testSearchByIngridient(_spoonacular);

            Console.WriteLine("-------------------------------------------------------------------------");
            //testGetSimilarRecipe(_spoonacular);

            Console.WriteLine("-------------------------------------------------------------------------");
            //testGetMatchingIngridients(_spoonacular);
        }

        private static void testGetMatchingIngridients(ISpoonacularService _spoonacular)
        {
            var ingridients = _spoonacular.GetMatchingIngredients("carrot").GetAwaiter().GetResult();
            foreach (Ingredient ingridient in ingridients)
            {
                Console.WriteLine(ingridient);
            }
        }

        private static void testGetSimilarRecipe(ISpoonacularService _spoonacular)
        {
            var recipes = _spoonacular.GetSimilarRecipe(655241).GetAwaiter().GetResult();
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(recipe);
            }

        }

        private static void testFreeSearch(ISpoonacularService _spoonacular)
        {
            var recipes = _spoonacular.GetRecipiesByFreeSearch("SOUP").GetAwaiter().GetResult();

            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(recipe);
            }
        }

        private static void testSearchByIngridient(ISpoonacularService _spoonacular)
        {
            List<Ingredient> ingridients = new List<Ingredient>() { new Ingredient() { Name = "egg" }, new Ingredient() { Name = "banana" } };
            var recipes = _spoonacular.GetRecipiesByIngredients(ingridients).GetAwaiter().GetResult();

            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(recipe);
            }
        }

        private static void testSearchByID(ISpoonacularService _spoonacular)
        {
            var specificRecipe = _spoonacular.GetRecipeById(655055).GetAwaiter().GetResult();
            Console.WriteLine(specificRecipe);
        }

        
    }
}
