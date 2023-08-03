using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ServiceAgent.Spoonacular.REntities;

namespace ServiceAgent.Spoonacular
{
    public class SpoonacularService : ISpoonacularService
    {

        readonly HttpClient client = new();

        readonly string url = $"https://api.spoonacular.com/";

        public const string SPOONACULAR_API_KEY = "4a7526f869174ac4828493187db94239";
        
        string? Parameters { get; set; }

        readonly string? key = $"apiKey={SPOONACULAR_API_KEY}";

        public SpoonacularService()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);
        }


        /// <returns>The complete query ready to be sent to the website</returns>
        private string? GetFullQuery()
        {
            return $"{Parameters}&{key}";
        }

        public async Task<IEnumerable<Recipe>> GetRecipiesByFreeSearch(string query)
        {
            List<Recipe> recipes = new();

            Parameters = $"recipes/complexSearch?query={query}";

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("response StatusCode is error");

            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var recipeList = JsonConvert.DeserializeObject<RecipeCollection>(jsonString);

            if (recipeList != null)
            {
                recipes.AddRange(recipeList.Recipes!);
            }
            return recipes;
        }

        public async Task<IEnumerable<Recipe>> GetRecipiesByIngridients(IEnumerable<Ingridient> ingridients)
        {

            if (!ingridients.Any())
                return new List<Recipe>();

            
            //findByIngredients?ingredients=apples,+flour,+sugar&number=2
            Parameters = $"recipes/findByIngredients?ingredients=";

            foreach (Ingridient ingridient in ingridients){
                    Parameters += ",+" + ingridient.Name;
            }

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("response StatusCode is error");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Recipe>>(jsonString)!;
        }

        public async Task<FullRecipe> GetRecipeById(int ID)
        {
            Parameters = $"recipes/informationBulk?ids={ID}";

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("response StatusCode is error");
            }
            var jsonString = await response.Content.ReadAsStringAsync();
            var recipeResponce = JsonConvert.DeserializeObject<IEnumerable<FullRecipe>>(jsonString);
            return recipeResponce!.FirstOrDefault()!;
        }

        public async Task<IEnumerable<Recipe>> GetSimilarRecipe(int ID)
        {
            parameters = $"recipes/{ID}/similar?";

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("response StatusCode is error");

            }
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Recipe>>(jsonString)!;
        }

        public async Task<IEnumerable<Ingridient>> GetMatchingIngridients(string ingridient)
        {
            Parameters = $"food/ingredients/search?query={ingridient}&number=10";

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("response StatusCode is error");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var recipeResponce = JsonConvert.DeserializeObject<IEnumerable<Ingridient>>(jsonString);
            return recipeResponce!;
        }
    }
}