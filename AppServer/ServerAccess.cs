﻿using AppServer.Models;
using ServiceAgent.Hebcal;
using ServiceAgent.Imagga;
using ServiceAgent.Spoonacular;
using ServiceAgent.Spoonacular.REntities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

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

        #region Spoonacular Service
        public FullRecipeData GetRecipeById(int ID)
        {
            FullRecipe recipe;

            try
            {
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
                                                     })
                                            // fetch the success data from the database
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
                    });
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