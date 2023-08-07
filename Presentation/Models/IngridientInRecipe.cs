using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class IngridientInRecipe
    {
        public string? Name { get; }

        public string? Image { get; }
       
        public int? ID { get; set; }

        public double Amount { get; set; }

        public string? Unit { get; set; }
    }
}
