using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class FullRecipe
    {
        public int ID { get; set; }

        public string? Title { get; set; }

        public string? Image { get; set; }

        public int ReadyInMinutes { get; set; }

        public int Servings { get; set; }

        public string? Summary { get; set; }

        public IEnumerable<IngredientInRecipe>? Ingridients { get; set; }

        public IEnumerable<RecipeStep>? Steps { get; set; }

        public SuccessData? SuccessData { get; set; }
    }
}
