using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options) { }

        //DbSet<Recipe> Recipes { get; set; } = null!;

        private DbSet<Recipe> recipes = null!;

        public DbSet<Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }
    }
}
