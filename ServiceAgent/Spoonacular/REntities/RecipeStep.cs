using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Spoonacular.REntities
{
    public class RecipeStep
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("step")]
        public string? Step { get; set;}

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
