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
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class SelectIngredientViewModel : ViewModelBase
    {        
        
        private NavigationStore _navigationStore;
        private readonly IServerAccess? _serverAccess;

        private string? _searchQuery = "Banana";

        public string? SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value; OnPropertyChanged(nameof(SearchQuery));
            }
        }

        private string? removeIngredientName;

        public string? RemoveIngredientName
        {
            get { return removeIngredientName; }
            set 
            { 
                removeIngredientName = value;
                OnPropertyChanged(nameof(RemoveIngredientName));
            }
        }

        private ObservableCollection<string?>? _ingredientList;

        public IEnumerable<string?>? IngredientList => _ingredientList;


        public ICommand? AddIngredientCommad => new CommandBase(execute => { _ingredientList!.Add(SearchQuery); 
                                                                             SearchQuery = string.Empty; },
                                                                canExecute => { return !string.IsNullOrEmpty(SearchQuery); });

        public ICommand? RemoveIngredientCommand => new CommandBase(execute => { _ingredientList?.Remove(execute as string); });

        public ICommand? SearchCommand => new CommandBase(execute => ApplySearch(), 
                                                          canExecute => { return _ingredientList == null || _ingredientList.Count() != 0; });

        private void ApplySearch()
        {
            try
            {
                var a = _serverAccess!.GetRecipiesByIngredients(IngredientList!);
                _navigationStore.CurrentViewModel = new RecipeListViewModel(_serverAccess, _navigationStore, a);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand? ReturnCommand => new ReturnViewCommand(_navigationStore);

        public SelectIngredientViewModel(IServerAccess? serverAccess, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _serverAccess = serverAccess;
            _ingredientList = new ObservableCollection<string?>() { "Banana"};
        }
    }
}
