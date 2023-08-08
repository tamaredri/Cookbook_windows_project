using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    internal class UsedDatesViewModel: ViewModelBase
    {
        private readonly UsedDate? _usedDate;

        public DateTime Date => _usedDate!.Date;
        public string? Description => _usedDate!.Description;

        public UsedDatesViewModel(UsedDate usedDate)
        {
            _usedDate = usedDate;
        }
    }
}
