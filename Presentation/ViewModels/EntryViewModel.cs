using Presentation.Commands.EntryViewCommands;
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
        public ICommand? FreeSearchCommand { get; }

        public ICommand? IngredientSearchCommand { get; }
        public ICommand? MyRecipesCommand { get; }

        public EntryViewModel()
        {
            //FreeSearchCommand = new OpenFreeSearchCommand();
            //IngredientSearchCommand = new OpenIngredientSearchCommand();
            //MyRecipesCommand = new GetMyRecipesCommand();
        }
    }
}
