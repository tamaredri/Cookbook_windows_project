using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    internal class EntryViewModel : ViewModelBase
    {
        public ICommand? FreeSearchCommand { get; set; }

        public ICommand? IngredientSearchCommand { get; set; }
        public ICommand? MyRecipesCommand { get; set; }
    }
}
