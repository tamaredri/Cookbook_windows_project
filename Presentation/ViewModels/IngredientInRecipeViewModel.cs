using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    internal class IngredientInRecipeViewModel : ViewModelBase
    {
        private readonly IngredientInRecipe? ingredientInRecie;

        public string? IngredientDescription => $"{ingredientInRecie!.Amount} {ingredientInRecie!.Unit} {ingredientInRecie!.Name}.";

        public IngredientInRecipeViewModel(IngredientInRecipe ingredient)
        {
            ingredientInRecie = ingredient;
        }

    }
}
