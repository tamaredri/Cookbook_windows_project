namespace AppServer.Models
{
    public class FullRecipeData
    {
        public int ID { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }

        //id,title,image
        public int ReadyInMinutes { get; set; }

        public int Servings { get; set; }

        public string? Summary { get; set; }

        // make a class for each one that will represent ingredientInRecipe and stepInRecipe
        public IEnumerable<IngredientForRecipeData>? Ingridients { get; set; }

        public IEnumerable<RecipeStepData>? Steps { get; set; }

        public DBRecipeSuccessData? SuccessData { get; set; } = new DBRecipeSuccessData();
    }
}
