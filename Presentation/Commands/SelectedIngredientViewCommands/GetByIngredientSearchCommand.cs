using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Commands.SelectedIngredientViewCommands
{
    internal class GetByIngredientSearchCommand : CommandBase
    {
        public GetByIngredientSearchCommand(Action<object>? execute, Func<object, bool>? canExecute = null) : base(execute, canExecute)
        {
        }
    }
}
