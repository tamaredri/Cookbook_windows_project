using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServiceAgent.Spoonacular.REntities
{
    public class IngridientInRecipe : Ingridient
    {
        //name, image

        [JsonProperty("id")]
        public int? ID { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unit")]
        public string? Unit { get; set; }

        public override string? ToString()
        {
            return $"ID: {ID},  name: {Name}, amount: {Amount}, unit: {Unit}, image: {Image}.";
        }
    }
}
