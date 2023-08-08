﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    internal class EntryViewModel : ViewModelBase
    {
        public ICommand? FreeSearchCommad { get; set; }

        public ICommand? IngredientSearchCommad { get; set; }
    }
}
