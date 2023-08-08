using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    internal class RecipeStepViewModel
    {
        private readonly RecipeStep? _recipeStep;
        public int Number => _recipeStep!.Number;

        public string? Step => _recipeStep!.Step;

        public RecipeStepViewModel(RecipeStep recipeStep)
        {
            _recipeStep = recipeStep;
        }
    }
}
