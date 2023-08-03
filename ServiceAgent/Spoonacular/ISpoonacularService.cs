using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceAgent.Spoonacular.REntities;


namespace ServiceAgent.Spoonacular
{
    public interface ISpoonacularService
    {
        Task<IEnumerable<Recipe>> GetRecipiesByFreeSearch(string query);
        Task<IEnumerable<Recipe>> GetRecipiesByIngridients(IEnumerable<Ingridient> ingridients);
        Task<FullRecipe> GetRecipeById(int ID);
        Task<IEnumerable<Recipe>> GetSimilarRecipe(int ID);

        Task<IEnumerable<Ingridient>> GetMatchingIngridients(string ingridient);
    }
}

