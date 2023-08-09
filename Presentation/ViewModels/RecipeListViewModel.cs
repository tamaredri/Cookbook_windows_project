using Presentation.Commands;
using Presentation.Commands.EntryViewCommands;
using Presentation.Models;
using Presentation.Stores;
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
        private NavigationStore _navigationStore;

        public RecipeListViewModel(NavigationStore navigation ,IEnumerable<RecipeToList> RecipesToList)
        {
            _navigationStore = navigation;
            _Recipes = new ObservableCollection<RecipeForListViewModel>((from r in RecipesToList
                                                                         select new RecipeForListViewModel(r))
                                                                         .ToList());
        }

        private ObservableCollection<RecipeForListViewModel>? _Recipes;
        public IEnumerable<RecipeForListViewModel>? Recipes => _Recipes;

        private RecipeForListViewModel? _selectedItem;
        public RecipeForListViewModel? SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); }
        }

        public ICommand? SelectRecipeCommand { get; set; }

        

    }
}
