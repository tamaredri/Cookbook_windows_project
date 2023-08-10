using AppServer.Models;

namespace Presentation.ViewModels
{
    public class RecipeStepViewModel :ViewModelBase
    {
        public int Number { get; }

        public string? Step { get; }

        public RecipeStepViewModel(RecipeStepData recipeStep)
        {
            Number = recipeStep!.Number;
            Step = recipeStep!.Step;
        }
    }
}
