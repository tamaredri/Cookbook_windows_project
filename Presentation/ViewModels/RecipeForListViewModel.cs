using AppServer.Models;

namespace Presentation.ViewModels
{
    public class RecipeForListViewModel : ViewModelBase
    {
        public int ID { get; set; }

        public string? Title { get; }

        public string? Image { get; }

        public RecipeForListViewModel(BasicRecipeData recipeToList)
        {
            ID = recipeToList.ID;
            Title = recipeToList.Title;
            Image = recipeToList.Image;
        }
    }
}
