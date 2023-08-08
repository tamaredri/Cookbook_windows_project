using Presentation.Commands.SelectedIngredientViewCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class SelectIngredientViewModel : ViewModelBase
    {
        public string? SearchIngredient { get; set; } = string.Empty;

        private ObservableCollection<string?>? _ingredientList;
        public IEnumerable<string?>? IngredientList => _ingredientList;

        public ICommand? AddIngredientCommand { get;}
        public ICommand? RemoveIngredientCommand { get;}
        public ICommand? SearchCommand { get;}


        public SelectIngredientViewModel()
        {
            _ingredientList = new ObservableCollection<string?>();

            AddIngredientCommand = new CreateIngredientToListCommand();
            RemoveIngredientCommand = new DeleteIngredientFromListCommand();
            SearchCommand = new GetByIngredientSearchCommand();
        }

    }
}
