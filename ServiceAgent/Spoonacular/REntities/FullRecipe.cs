using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Spoonacular.REntities
{
    public class FullRecipe : Recipe
    {
        //id,title,image
        [JsonProperty("extendedIngredients")]
        public List<IngridientInRecipe>? Ingridients { get; set; }

        [JsonProperty("readyInMinutes")]
        public int ReadyInMinutes { get; set; }

        [JsonProperty("servings")]
        public int Servings { get; set; }

        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [JsonProperty("steps")]
        public List<RecipeStep>? steps { get; set; }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
