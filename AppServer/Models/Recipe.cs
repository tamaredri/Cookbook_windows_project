namespace WebAPI.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public int RecipeRating { get; set; }

        public IEnumerable<UsedDate>? RecipeDates { get; set; }

        //public IEnumerable<Image>? RecipeImages { get; set; }
    }
}
