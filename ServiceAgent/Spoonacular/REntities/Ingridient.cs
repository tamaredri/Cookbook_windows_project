using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServiceAgent.Spoonacular.REntities
{
    public class Ingridient
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("image")]
        public string? Image { get; set; }
    }
}
