using AppServer;
using Presentation.Commands;
using AppServer.Models;
using Presentation.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Presentation.ViewModels
{
    public class RecipeListViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        private readonly IServerAccess? _serverAccess;

        public RecipeListViewModel(IServerAccess? serverAccess, 
                                   NavigationStore navigation, 
                                   IEnumerable<BasicRecipeData> RecipesToList)
        {
            _navigationStore = navigation;
            _serverAccess = serverAccess;
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
            set 
            { 
                _selectedItem = value; 
                OnPropertyChanged(nameof(SelectedItem)); 
            }
        }

        public ICommand? ReturnCommand => new ReturnViewCommand(_navigationStore);

        public ICommand? SelectRecipeCommand => new CommandBase(execute => OpenRecipe());

        private void OpenRecipe()
        {
            try
            {
                var selectedRecipe = _serverAccess!.GetRecipeById(SelectedItem!.ID);
                _navigationStore.CurrentViewModel = new FullRecipeViewModel(_serverAccess,
                                                                           _navigationStore,
                                                                            selectedRecipe);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        

    }
}
