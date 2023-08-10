using AppServer.Models;

namespace AppServer
{
    public interface IServerAccess
    {
        #region Spoonacular API
        /// <summary>
        /// Get a collection of basic representation of recipes. 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IEnumerable<BasicRecipeData> GetRecipiesByFreeSearch(string query);

        /// <summary>
        /// Get a collection of basic representation of recipes.
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        IEnumerable<BasicRecipeData> GetRecipiesByIngredients(IEnumerable<string?> ingredients);

        /// <summary>
        /// Get a singke recipe - full representation
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        FullRecipeData GetRecipeById(int ID);

        /// <summary>
        /// Get a collection of 10 REcipes that are similar to the given recipe (ID)
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        IEnumerable<BasicRecipeData> GetSimilarRecipes(int ID);
        #endregion

        #region Hebcal
        UsedDate GetDateEvent();
        #endregion
    }
}
