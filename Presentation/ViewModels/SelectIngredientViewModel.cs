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

        public ICommand? AddIngredientCommad { get; set; }

        public ICommand? SearchCommand { get; set; }

        public ICommand? RemoveIngredientCommand { get; set; }

        public SelectIngredientViewModel()
        {
            _ingredientList = new ObservableCollection<string?>() { "banana", "apple"};
        }

    }
}
