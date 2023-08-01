using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/Recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeContext _dbContext;

        public RecipesController(RecipeContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Rcepies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            if (_dbContext.Recipes == null) { return NotFound(); }

            return await _dbContext.Recipes.ToListAsync();
        }

        // GET: api/Rcepies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            if (_dbContext.Recipes == null) { return NotFound(); }
            var recipe = await _dbContext.Recipes.FindAsync(id);

            if (recipe == null) { return NotFound(); }
            return recipe;
        }

        // POST: api/Rcepies
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe),
                                   new { Id = recipe.Id, RecipeRating = recipe.RecipeRating },
                                   recipe);
        }

        // PUT: api/Rcepies/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Recipe>> PutRecipe(int id, Recipe recipe)
        {
            if(id != recipe.Id) { return BadRequest(); }

            _dbContext.Entry(recipe).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id)) { return NotFound(); }
                else { throw; }
            }

            return NoContent();
        }

        private bool RecipeExists(int id) =>
            (_dbContext.Recipes?.Any(e => e.Id == id)).GetValueOrDefault();

        // DELETE: api/Rcepies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            if (_dbContext.Recipes == null) { return NotFound(); }

            var recipe = await _dbContext.Recipes.FindAsync(id);

            if (recipe == null) { return NotFound(); }

            _dbContext.Recipes.Remove(recipe);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
