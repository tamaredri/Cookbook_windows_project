using AppServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class IngredientInRecipeViewModel : ViewModelBase
    {
        public string? IngredientDescription { get; }

        public IngredientInRecipeViewModel(IngredientForRecipeData ingredient)
        {
            IngredientDescription = $"{ingredient!.Amount} {ingredient!.Unit} {ingredient!.Name}.";
        }
    }
}
