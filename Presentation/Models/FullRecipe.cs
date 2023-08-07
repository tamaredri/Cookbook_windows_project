using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class FullRecipe
    {
        public int ID { get; }

        public string? Title { get; }

        public string? Image { get; }

        public int ReadyInMinutes { get; set; }

        public int Servings { get; set; }

        public string? Summary { get; set; }

        public IEnumerable<IngridientInRecipe>? Ingridients { get; set; }

        public IEnumerable<RecipeStep>? Steps { get; set; }

        public SuccessData? SuccessData { get; set; }
    }
}
