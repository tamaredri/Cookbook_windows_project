using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class RecipeListViewModel : ViewModelBase
    {
        private ObservableCollection<FullRecipeViewModel>? _FullRecipes;
        public IEnumerable<FullRecipeViewModel>? FullRecipes => _FullRecipes;

        public RecipeListViewModel(IEnumerable<FullRecipeViewModel> FullRecipes) 
        {
            
        }
    }
}
