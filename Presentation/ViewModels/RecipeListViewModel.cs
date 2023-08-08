using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class RecipeListViewModel : ViewModelBase
    {
        private ObservableCollection<RecipeForListViewModel>? _Recipes;
        public IEnumerable<RecipeForListViewModel>? Recipes => _Recipes;

        public ICommand? SelectRecipeCommand { get; set; }

        public RecipeListViewModel(ObservableCollection<RecipeForListViewModel> RecipesToList) 
        {
            _Recipes = RecipesToList;
        }
    }
}
