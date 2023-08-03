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
        #region fields
        readonly HttpClient client = new();

        readonly string url = $"https://api.spoonacular.com/";

        public const string SPOONACULAR_API_KEY = "eccecffd02a843c18dd94bd0e3497f09";
        
        string? Parameters { get; set; }

        readonly string? key = $"apiKey={SPOONACULAR_API_KEY}";
        #endregion

        public SpoonacularService()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);
        }

        /// GetFullQuery Doc
        /// <returns>The complete query ready to be sent to the website
        /// </returns>
        private string? GetFullQuery()
        {
            return $"{Parameters}&{key}";
        }

        #region interface implementation
        public async Task<IEnumerable<Recipe>> GetRecipiesByFreeSearch(string query)
        {
            Parameters = $"recipes/complexSearch?query={query}";

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new Exception("response StatusCode is error");
            
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            return jsonObject!.results.ToObject<IEnumerable<Recipe>>();
        }

        public async Task<IEnumerable<Recipe>> GetRecipiesByIngridients(IEnumerable<Ingridient> ingridients)
        {
            if (!ingridients.Any())
                return new List<Recipe>();
            
            Parameters = $"recipes/findByIngredients?ingredients=";
            foreach (Ingridient ingridient in ingridients)
                    Parameters += ",+" + ingridient.Name;

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception("response StatusCode is error");

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Recipe>>(jsonString)!;
        }

        public async Task<FullRecipe> GetRecipeById(int ID)
        {
            Parameters = $"recipes/informationBulk?ids={ID}";

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new Exception("response StatusCode is error");
            var jsonString = await response.Content.ReadAsStringAsync();
            var recipeResponce = JsonConvert.DeserializeObject<IEnumerable<FullRecipe>>(jsonString)!.FirstOrDefault()!;

            //extract the steps from the json object
            var recipeInstructions = JsonConvert.DeserializeObject<dynamic>(jsonString)!;
            recipeResponce.Steps = recipeInstructions[0]!.analyzedInstructions[0].steps.ToObject<IEnumerable<RecipeStep>>();
            return recipeResponce;
        }

        public async Task<IEnumerable<Recipe>> GetSimilarRecipe(int ID)
        {
            Parameters = $"recipes/{ID}/similar?";

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
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);

            return jsonObject!.results.ToObject<IEnumerable<Ingridient>>();
        }
        #endregion
    }
}