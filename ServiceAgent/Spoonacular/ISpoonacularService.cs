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
        /// <summary>
        /// Request a list of recipes from Spoonacular according to key words.
        /// </summary>
        /// <param name="query">key word to search</param>
        /// <returns>collection of recipes matching the query</returns>
        Task<IEnumerable<Recipe>> GetRecipiesByFreeSearch(string query);

        /// <summary>
        /// Request a list of recipes from Spoonacular that use the requesteg ingridients.
        /// </summary>
        /// <param name="ingridients">collections of ingridients for the search</param>
        /// <returns>collection of recipes using the ingridients</returns>
        Task<IEnumerable<Recipe>> GetRecipiesByIngridients(IEnumerable<Ingridient> ingridients);

        /// <summary>
        /// Request a specific recipe using an ID number.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>the requested recipe</returns>
        Task<FullRecipe> GetRecipeById(int ID);

        /// <summary>
        /// Request 10 recipes that are most similar to the requested recipe.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>collection of similar recipes</returns>
        Task<IEnumerable<Recipe>> GetSimilarRecipe(int ID);

        /// <summary>
        /// Request 10 ingridients that match the ingridients query
        /// </summary>
        /// <param name="ingridient">ingridient name to search</param>
        /// <returns>collection of matching ingridients</returns>
        Task<IEnumerable<Ingridient>> GetMatchingIngridients(string ingridient);
    }
}

