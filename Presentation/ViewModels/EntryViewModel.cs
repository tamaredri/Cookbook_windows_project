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
    internal class EntryViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        private readonly IServerAccess? _serverAccess;

        public EntryViewModel(IServerAccess? serverAccess, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _serverAccess = serverAccess;
        }

        public ICommand? FreeSearchCommand => new CommandBase(execute =>
                                                                _navigationStore.CurrentViewModel = new FreeSearchViewModel(_serverAccess, _navigationStore));

        public ICommand? IngredientSearchCommand => new CommandBase(execute =>
                                                                _navigationStore.CurrentViewModel = new SelectIngredientViewModel(_serverAccess, _navigationStore));

        public ICommand? MyRecipesCommand => new CommandBase(execute => ApplySearch());

        private void ApplySearch()
        {
            try
            {
                var a = _serverAccess!.GetRecipiesFromDB();
                _navigationStore.CurrentViewModel = new RecipeListViewModel(_serverAccess, _navigationStore, a);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
