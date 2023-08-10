using AppServer.Models;
using ServiceAgent.Spoonacular;
using ServiceAgent.Spoonacular.REntities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace AppServer
{
    public class ServerAccess : IServerAccess
    {
        private readonly ISpoonacularService _spoonacularService;

        public ServerAccess()
        {
            _spoonacularService = new SpoonacularService();
        }


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
    }
}
