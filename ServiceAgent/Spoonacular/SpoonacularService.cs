using Newtonsoft.Json;
using ServiceAgent.Spoonacular.REntities;
using System.Net.Http.Headers;

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
        private string? GetFullQuery() { return $"{Parameters}&{key}"; }

        #region interface implementation
        public async Task<IEnumerable<Recipe>> GetRecipiesByFreeSearch(string query)
        {
            Parameters = $"recipes/complexSearch?query={query}";

            HttpResponseMessage response = await client.GetAsync(GetFullQuery())
                                                       .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new Exception("response StatusCode is error");
            
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);
            return jsonObject!.results.ToObject<IEnumerable<Recipe>>();
        }

        public async Task<IEnumerable<Recipe>> GetRecipiesByIngredients(IEnumerable<string> ingredients)
        {
            if (!ingredients.Any())
                return new List<Recipe>();
            
            Parameters = $"recipes/findByIngredients?ingredients=";
            foreach (string ingredient in ingredients)
                    Parameters += ",+" + ingredient;

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
            var recipeResponse = JsonConvert.DeserializeObject<IEnumerable<FullRecipe>>(jsonString)!.FirstOrDefault()!;

            //extract the steps from the json object
            var dynamicRecipeResponse = JsonConvert.DeserializeObject<dynamic>(jsonString)!;
            var analyzedInstructionsProperty = dynamicRecipeResponse[0]!.analyzedInstructions;
            if (analyzedInstructionsProperty.HasValues)
                recipeResponse.Steps = analyzedInstructionsProperty[0].steps.ToObject<IEnumerable<RecipeStep>>();
            else recipeResponse.Steps = new List<RecipeStep>();

            return recipeResponse;
        }

        public async Task<IEnumerable<Recipe>> GetSimilarRecipes(int ID)
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

        public async Task<IEnumerable<Ingredient>> GetMatchingIngredients(string ingredient)
        {
            Parameters = $"food/ingredients/search?query={ingredient}&number=10";

            HttpResponseMessage response = await client.GetAsync(GetFullQuery()).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("response StatusCode is error");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonString);

            return jsonObject!.results.ToObject<IEnumerable<Ingredient>>();
        }
        #endregion
    }
}