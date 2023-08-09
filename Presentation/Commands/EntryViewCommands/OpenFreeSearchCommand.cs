using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Commands.EntryViewCommands
{
    public class OpenFreeSearchCommand : CommandBase
    {
        public OpenFreeSearchCommand(Action<object>? execute, Func<object, bool>? canExecute = null) : base(execute, canExecute)
        {
        }
    }
}
