using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Spoonacular.REntities
{
    public class Instruction
    {
        [JsonProperty("steps")]
        public IEnumerable<RecipeStep>? Steps { get; set; }

        public override string? ToString()
        {
            string result = string.Empty;
            foreach (RecipeStep step in Steps!)
            {
                result += step + "\n";
            }
            return result;
        }
    }
}
