using AppServer.Models;
using Newtonsoft.Json;
using ServiceAgent.Hebcal;
using ServiceAgent.Imagga;
using ServiceAgent.Spoonacular;
using ServiceAgent.Spoonacular.REntities;
using System.Net.Http.Headers;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Text;

namespace AppServer
{
    public class ServerAccess : IServerAccess
    {
        private readonly ISpoonacularService _spoonacularService;
        private readonly IHebcalService _hebcalService;
        private readonly IImaggaService _imaggaService;

        public ServerAccess()
        {
            _spoonacularService = new SpoonacularService();
            _hebcalService = new HebcalService();
            _imaggaService = new ImaggaService();
        }


        #region DBRecipe
        private async Task<RecipeDB> GetRecipeDBById(int ID)
        {
            HttpClient client = new();
            string url = $"https://localhost:7089";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);
            string Parameters = $"/api/Recipes/{ID}";

            HttpResponseMessage response = await client.GetAsync(Parameters).ConfigureAwait(false);
            
            // the recipe does not exist in the data base
            if (response.StatusCode == HttpStatusCode.NotFound)
                return new RecipeDB();


            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());

            var jsonString = await response.Content.ReadAsStringAsync();
            var recipeResponse = JsonConvert.DeserializeObject<RecipeDB>(jsonString);

            return recipeResponse!;
        }

        public async Task<IEnumerable<RecipeDB>> GetAllSavedRecipesFromDB()
        {
            HttpClient client = new();
            string url = $"https://localhost:7089";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);
            string Parameters = $"/api/Recipes";

            HttpResponseMessage response = await client.GetAsync(Parameters).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new Exception("response StatusCode is error");

            var jsonString = await response.Content.ReadAsStringAsync();
            var recipeResponse = JsonConvert.DeserializeObject<IEnumerable<RecipeDB>>(jsonString);

            return recipeResponse!;
        }

        private async Task SaveRecipeDById(RecipeDB recipeDB)
        {
            HttpClient client = new();
            string url = $"https://localhost:7089";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);
            string Parameters = $"/api/Recipes";

            string? jsonContent = JsonConvert.SerializeObject(recipeDB);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(Parameters + $"/{recipeDB.ID}", content).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                response = await client.PostAsync(Parameters, content).ConfigureAwait(false);
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ToString());
        }

        public void SaveOrUpdateRacipeToDB(RecipeDB recipeDB)
        {
            try
            {
                SaveRecipeDById(recipeDB).GetAwaiter().GetResult();
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion

        //--------------------------------------------------------------------

        #region Spoonacular Service
        public FullRecipeData GetRecipeById(int ID)
        {
            FullRecipe recipe;

            try
            {  
                RecipeDB r_Db = GetRecipeDBById(ID)
                                           .GetAwaiter().GetResult();

                recipe = _spoonacularService.GetRecipeById(ID)
                                           .GetAwaiter().GetResult();

                return new FullRecipeData { ID = recipe.ID,
                                            Image = recipe.Image,
                                            Title = recipe.Title,
                                            Summary = recipe.Summary,
                                            Servings = recipe.Servings, 
                                            ReadyInMinutes = recipe.ReadyInMinutes,
                                            Ingridients = (from i in recipe.Ingridients
                                                           select new IngredientForRecipeData()
                                                           {
                                                               Name = i.Name,
                                                               Amount = i.Amount,
                                                               Unit = i.Unit
                                                           }),
                                            Steps = (from r in recipe.Steps
                                                     select new RecipeStepData()
                                                     {
                                                         Number = r.Number,
                                                         Step = r.Step
                                                     }),
                                            SuccessData = r_Db

                };

            }
            catch (Exception) { throw; }
        }

        public IEnumerable<BasicRecipeData> GetRecipiesByFreeSearch(string query)
        {
            IEnumerable<Recipe> recipes;
            try
            { recipes = _spoonacularService.GetRecipiesByFreeSearch(query)
                                           .GetAwaiter().GetResult(); }
            catch (Exception) { throw; }

            return (from r in recipes
                    select new BasicRecipeData() { ID = r.ID, 
                                                   Image =  r.Image,
                                                   Title = r.Title });
        }

        public IEnumerable<BasicRecipeData> GetRecipiesByIngredients(IEnumerable<string?> ingredients)
        {
            IEnumerable<Recipe> recipes;
            try
            {
                recipes = _spoonacularService.GetRecipiesByIngredients(ingredients!)
                                           .GetAwaiter().GetResult();
            }
            catch (Exception) { throw; }

            return (from r in recipes
                    select new BasicRecipeData()
                    {
                        ID = r.ID,
                        Image = r.Image,
                        Title = r.Title
                    });
        }

        public IEnumerable<BasicRecipeData> GetRecipiesFromDB()
        {
            IEnumerable<RecipeDB> recipesDB = GetAllSavedRecipesFromDB().GetAwaiter().GetResult();

            return (from r in recipesDB
                    let sr = GetRecipeById(r.ID)
                    select new BasicRecipeData()
                    {
                        ID = sr.ID,
                        Image = sr.Image,
                        Title = sr.Title
                    }).ToList();
        }

        public IEnumerable<BasicRecipeData> GetSimilarRecipes(int ID)
        {
            IEnumerable<Recipe> recipes;
            try
            {
                recipes = _spoonacularService.GetSimilarRecipes(ID)
                                           .GetAwaiter().GetResult();
            }
            catch (Exception) { throw; }

            return (from r in recipes
                    select new BasicRecipeData()
                    {
                        ID = r.ID,
                        Image = r.Image,
                        Title = r.Title
                    }).ToList();
        }
        #endregion

        //------------------------------------------------------------------

        #region HebCal Service
        public UsedDate GetDateEvent()
        {
            try
            {
                DateInformation useDate = _hebcalService.GetHebrewEvent(DateTime.Now, DateTime.Now.AddDays(3))
                                           .GetAwaiter().GetResult();

                return new UsedDate() { Date = useDate.Date, Description = useDate.Title /*ID*/};
            }
            catch (Exception) { throw; }
        }
        #endregion

        //------------------------------------------------------------------

        #region Imagga service
        public bool DoesImageMatchRecipe(string spoonacularUrl, string newUrl)
        {
            bool doesNeedDelete = false;

            if(!newUrl.Contains("http")) 
            {
                doesNeedDelete = true;
                newUrl = _imaggaService.UploadImageToServer(newUrl);
            }

            bool canUpload = _imaggaService.IsSimilarImages(spoonacularUrl, newUrl);

            if(doesNeedDelete) 
            {
                _imaggaService.DeleteImageFromServer(newUrl);
            }
            return canUpload;
        }
        #endregion
    }
}
