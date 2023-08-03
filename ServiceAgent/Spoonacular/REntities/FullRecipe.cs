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
        [JsonProperty("readyInMinutes")]
        public int ReadyInMinutes { get; set; }

        [JsonProperty("servings")]
        public int Servings { get; set; }

        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [JsonProperty("extendedIngredients")]
        public IEnumerable<IngridientInRecipe>? Ingridients { get; set; }

        [JsonProperty("analyzedInstructions")]
        public IEnumerable<Instruction>? AnalyzedInstructions { get; set; }

        public override string? ToString()
        {
            string? ingridientsDescription = "";
            if (Ingridients != null)
                foreach (var i in Ingridients)
                    ingridientsDescription += $"{i}\n";       
            
            return $"Full recipe:\n{base.ToString()}\n" +
                   $"Suitable for {Servings} people.\n\n" +
                   $"Summary:\n{Summary}\n\n" +
                   $"Ingridients:\n{ingridientsDescription}\n\n" +
                   $"Steps:\n{AnalyzedInstructions!.FirstOrDefault()}";
        }
    }
}
