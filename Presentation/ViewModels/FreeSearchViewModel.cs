using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class FreeSearchViewModel : ViewModelBase
    {
        public string? SearchQuery { get; set; }

        public ICommand? ApplySearchCommand { get; set; }

    }
}
