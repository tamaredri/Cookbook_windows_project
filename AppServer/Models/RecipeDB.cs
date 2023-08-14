using Newtonsoft.Json;

namespace AppServer.Models
{
    public class RecipeDB
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("recipeRating")]
        public int RecipeRating { get; set; }

        [JsonProperty("comment")]
        public string? Comment { get; set; } = "";

        [JsonProperty("recipeDates")]
        public IEnumerable<UsedDate>? RecipeDates { get; set; } = new List<UsedDate>();

        [JsonProperty("recipeImages")]
        public IEnumerable<ImagePath>? RecipeImages { get; set; } = new List<ImagePath>();
    }
}
