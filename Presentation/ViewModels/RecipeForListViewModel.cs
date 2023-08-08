using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class RecipeForListViewModel : ViewModelBase
    {
        private RecipeToList _RecipeToList;

        public string? Title => _RecipeToList.Title;

        public string? Image => _RecipeToList.Image;

        public RecipeForListViewModel(RecipeToList recipeToList)
        {
            _RecipeToList = recipeToList;
        }
    }
}
