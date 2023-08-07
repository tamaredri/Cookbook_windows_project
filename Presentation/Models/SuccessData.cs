using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class SuccessData
    {
        public int Rating { get; set; }

        public string? Comment { get; set; }

        public List<string>? Images { get; set; }

        public List<UsedDate>? usedDates { get; set; }
    }
}
