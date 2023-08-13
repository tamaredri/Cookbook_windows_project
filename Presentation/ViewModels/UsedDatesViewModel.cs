using AppServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class UsedDatesViewModel: ViewModelBase
    {
        public string? Date { get; }
        public string? Description { get; }

        public UsedDatesViewModel(UsedDate usedDate)
        {
            Date = $"{usedDate!.Date.Day.ToString("00")}/{usedDate!.Date.Month.ToString("00")}/{usedDate!.Date.Year.ToString("0000")}";
            Description = usedDate!.Description; 
        }
    }
}
