using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiceAgent.Spoonacular.REntities
{
    [Serializable]
    public class Recipe
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("image")]
        public string? Image { get; set; } = "https://spoonacular.com/IngredientImages/sliced-carrot.png";

        public override string? ToString()
        {
            return $"ID: {ID}, title: {Title}, image: {Image}.";
        }
    }
}
