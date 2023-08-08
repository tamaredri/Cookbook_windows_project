using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class UsedDatesViewModel: ViewModelBase
    {
        private readonly UsedDate? _usedDate;

        public string? Date => $"{_usedDate!.Date.Day}/{_usedDate!.Date.Month}/{_usedDate!.Date.Year}";
        public string? Description => _usedDate!.Description;

        public UsedDatesViewModel(UsedDate usedDate)
        {
            _usedDate = usedDate;
        }
    }
}
