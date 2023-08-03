using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Spoonacular.REntities
{
    [Serializable]
    public class RecipeCollection
    {
        [JsonProperty("results")]
        public IEnumerable<Recipe>? Recipes { get; set; }

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("totalResult")]
        public int? TotalResult { get; set; }

        public override string? ToString()
        {
            string? result = "Recipe:\n";

            foreach(Recipe recipe in Recipes!)
            {
                result += $"{recipe}\n";
            }

            result += $"number: {Number}, total result: {TotalResult}.";
            return result;
        }
    }
}