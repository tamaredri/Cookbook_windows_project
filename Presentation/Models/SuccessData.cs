using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class SuccessData
    {
        public int ID { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public List<string>? Images { get; set; } = new List<string>();

        public List<UsedDate>? usedDates { get; set; } = new List<UsedDate>();
    }
}
