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

        // GET: api/Rcepies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDB>>> GetRecipes()
        {
            if (_dbContext.Recipes == null) { return NotFound(); }

            return await _dbContext.Recipes.Include(r => r.RecipeDates)
                                           .Include(r => r.RecipeImages)
                                           .ToListAsync();
        }

        // GET: api/Rcepies/5
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

        // POST: api/Rcepies
        [HttpPost]
        public async Task<ActionResult<RecipeDB>> PostRecipe(RecipeDB recipe)
        {
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe),
                                   new { Id = recipe.ID },
                                   recipe);
        }

        // PUT: api/Rcepies/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RecipeDB>> PutRecipe(int id, RecipeDB updatedRecipe)
        {
            if (id != updatedRecipe.ID)
            {
                return BadRequest();
            }

            var existingRecipe = await _dbContext.Recipes.Include(r => r.RecipeDates)
                                                      .Include(r => r.RecipeImages)
                                                      .FirstOrDefaultAsync(r => r.ID == id);

            if (existingRecipe == null)
            {
                return NotFound();
            }

            // Update properties of the main entity
            existingRecipe.RecipeRating = updatedRecipe.RecipeRating;
            existingRecipe.Comment = updatedRecipe.Comment;

            // Update or add RecipeDates
            foreach (var updatedDate in updatedRecipe.RecipeDates!)
            {
                var existingDate = existingRecipe.RecipeDates!.FirstOrDefault(d => d.ID == updatedDate.ID);

                if (existingDate != null)
                {
                    _dbContext.Entry(existingDate).CurrentValues.SetValues(updatedDate);
                }
                else
                {
                    existingRecipe.RecipeDates.Add(updatedDate);
                }
            }

            // Update or add RecipeImages
            foreach (var updatedImage in updatedRecipe.RecipeImages!)
            {
                var existingImage = existingRecipe.RecipeImages?.FirstOrDefault(i => i.ID == updatedImage.ID);

                if (existingImage != null)
                {
                    _dbContext.Entry(existingImage).CurrentValues.SetValues(updatedImage);
                }
                else
                {
                    existingRecipe.RecipeImages.Add(updatedImage);
                }
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        private bool RecipeExists(int id) =>
            (_dbContext.Recipes?.Any(e => e.ID == id)).GetValueOrDefault();

        // DELETE: api/Rcepies/5
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
