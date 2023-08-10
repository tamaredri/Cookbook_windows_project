using Microsoft.EntityFrameworkCore;

namespace AppServer.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options) { }

        //DbSet<Recipe> Recipes { get; set; } = null!;

        private DbSet<RecipeDB> recipes = null!;

        public DbSet<RecipeDB> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }
    }
}
