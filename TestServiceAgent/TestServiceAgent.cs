using ServiceAgent.Spoonacular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using ServiceAgent.Spoonacular.REntities;
using ServiceAgent.Hebcal;
using ServiceAgent.Imagga;
using System.Globalization;
using RestSharp;
using static System.Net.WebRequestMethods;

namespace ServiceAgent
{
    internal class TestServiceAgent
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Testing:");

            ISpoonacularService _spoonacular = new SpoonacularService();
            IImaggaService imaggaService = new ImaggaService();
            //testFreeSearch(_spoonacular);

            Console.WriteLine("-------------------------------------------------------------------------");
            //testSearchByID(_spoonacular);

            Console.WriteLine("-------------------------------------------------------------------------");
            //testSearchByIngridient(_spoonacular);

            Console.WriteLine("-------------------------------------------------------------------------");
            //testGetSimilarRecipe(_spoonacular);

            Console.WriteLine("-------------------------------------------------------------------------");
            //testGetMatchingIngridients(_spoonacular);

            Console.WriteLine("-------------------------------------------------------------------------");
            //testGetDate(new HebcalService());

            Console.WriteLine("-------------------------------------------------------------------------");
            //testDeleteImage(imaggaService, testUploadImage(imaggaService));

            Console.WriteLine("-------------------------------------------------------------------------");
            testSimilarImages(imaggaService);
        }



        #region test spoonacular
        private static void testGetDate(IHebcalService _hebcalService)
        {
            DateInformation d = _hebcalService.GetHebrewEvent(/*new DateTime(2015, 05 , 23), new DateTime(2015, 05, 23)*/DateTime.Now, DateTime.Now.AddDays(1)
                ).GetAwaiter().GetResult();
            Console.WriteLine(d);
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
            var recipes = _spoonacular.GetSimilarRecipes(655241).GetAwaiter().GetResult();
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
            List<string> ingridients = new List<string>() {  "egg" , "banana" };
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
        #endregion


        #region test imagga

        public static string testUploadImage(IImaggaService imaggaService)
        {
            string UploadId = imaggaService.UploadImageToServer(@"C:\Users\Dror\source\repos\dotNet5782_7612_5986\PL\Icons\customer.png");
            Console.WriteLine(UploadId);

            return UploadId;
        }

        public static void testDeleteImage(IImaggaService imaggaService, string UploadId)
        {
            imaggaService.DeleteImageFromServer(UploadId);
            Console.WriteLine("seccesfully Deleted");
        }

        private static void testSimilarImages(IImaggaService imaggaService)
        {
            testUploadUploadSimilarImages(imaggaService);

            testUrlUploadSimilarImages(imaggaService);

            testUrlUrlSimilarImages(imaggaService);
        }

        private static void testUploadUploadSimilarImages(IImaggaService imaggaService)
        {
            string UploadId = imaggaService.UploadImageToServer(@"C:\Users\Dror\source\repos\dotNet5782_7612_5986\PL\Icons\customer.png");
            string UploadId1 = imaggaService.UploadImageToServer(@"C:\Users\Dror\source\repos\dotNet5782_7612_5986\PL\Images\map.png");

            Console.WriteLine(imaggaService.IsSimilarImages(UploadId, UploadId1));

            testDeleteImage(imaggaService, UploadId);
            testDeleteImage(imaggaService, UploadId1);
        }

        private static void testUrlUploadSimilarImages(IImaggaService imaggaService)
        {
            string UploadId = imaggaService.UploadImageToServer(@"C:\Users\Dror\source\repos\dotNet5782_7612_5986\PL\Icons\customer.png");
            string UploadId1 = "https://assets.bonappetit.com/photos/62b1f8f4ee3de8c374121bac/1:1/w_2560%2Cc_limit/20220615-0622-sandwiches-1779-final.jpg";

            Console.WriteLine(imaggaService.IsSimilarImages(UploadId, UploadId1));

            testDeleteImage(imaggaService, UploadId);
        }

        private static void testUrlUrlSimilarImages(IImaggaService imaggaService)
        {
            string UploadId = "https://www.eatingwell.com/thmb/vFO43UyAy2NBfjOG6wADLLCE-Kc=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/cucumber-sandwich-eddcc95811f5426094ea5dbea6a6b026.jpg";
            string UploadId1 = "https://assets.bonappetit.com/photos/62b1f8f4ee3de8c374121bac/1:1/w_2560%2Cc_limit/20220615-0622-sandwiches-1779-final.jpg";

            Console.WriteLine(imaggaService.IsSimilarImages(UploadId, UploadId1));
        }
        #endregion

    }
}
