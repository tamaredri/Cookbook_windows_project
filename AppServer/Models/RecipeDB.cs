namespace AppServer.Models
{
    public class RecipeDB
    {
        public int ID { get; set; }

        public int RecipeRating { get; set; }
        public string? Comment { get; set; }

        public IEnumerable<UsedDate>? RecipeDates { get; set; }

        public IEnumerable<ImagePath>? RecipeImages { get; set; }
    }
}
