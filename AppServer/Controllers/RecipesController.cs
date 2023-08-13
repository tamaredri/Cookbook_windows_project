using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AppServer.Controllers
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

        // GET: api/Rcepies/Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDB>>> GetRecipes()
        {
            if (_dbContext.Recipes == null) { return NotFound(); }

            return await _dbContext.Recipes.Include(r => r.RecipeDates)
                                           .Include(r => r.RecipeImages)
                                           .ToListAsync();
        }

        // GET: api/Rcepie/Get/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDB>> GetRecipe(int id)
        {
            if (_dbContext.Recipes == null) { return NotFound(); }
            var recipe = await _dbContext.Recipes.Include(r => r.RecipeDates)
                                                  .Include(r => r.RecipeImages)
                                                  .FirstOrDefaultAsync(r => r.ID == id);

            if (recipe == null) { return NotFound(); }
            return recipe;
        }

        // POST: api/Rcepie/Add
        [HttpPost]
        public async Task<ActionResult<RecipeDB>> PostRecipe(RecipeDB recipe)
        {
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe),
                                   new { Id = recipe.ID },
                                   recipe);
        }

        // PUT: api/Rcepie/Update/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RecipeDB>> PutRecipe(int id, RecipeDB recipe)
        {
            if(id != recipe.ID) { return BadRequest(); }

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
            (_dbContext.Recipes?.Any(e => e.ID == id)).GetValueOrDefault();

        // DELETE: api/Rcepies/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecipeDB>> DeleteRecipe(int id)
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
