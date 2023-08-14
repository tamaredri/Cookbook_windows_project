using AppServer;
using Presentation.Commands;
using Presentation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class FreeSearchViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        private readonly IServerAccess? _serverAccess;

        public FreeSearchViewModel(IServerAccess? serverAccess, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _serverAccess = serverAccess;
        }

        private string? _searchQuery = "Chocolate Cake";
        public string? SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value; OnPropertyChanged(nameof(SearchQuery));
            }
        }

        public ICommand? ApplySearchCommand => new CommandBase(e => OnApplySearchCommand(), 
                                                               canExecute => CanApplySearch());

        private void OnApplySearchCommand()
        {
            try
            {
                var a = _serverAccess!.GetRecipiesByFreeSearch(SearchQuery!);
                _navigationStore.CurrentViewModel = new RecipeListViewModel(_serverAccess, _navigationStore, a);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanApplySearch()
        {
            return !string.IsNullOrEmpty(SearchQuery);
        }

        public ICommand? ReturnCommand => new ReturnViewCommand(_navigationStore);

    }
}
