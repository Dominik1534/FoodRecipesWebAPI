using AutoMapper;
using FoodRecipesWebAPI.Entities;
using FoodRecipesWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodRecipesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeDbContext _recipeDbContext;
        private readonly IMapper _mapper;
        public RecipeController(RecipeDbContext recipeDbContext ,IMapper mapper) 
        {
            _recipeDbContext = recipeDbContext;
            _mapper = mapper;

        }

        // GET: api/<RecipeController>
   
        [HttpGet("{id}")]
        public ActionResult<RecipeDto> Get([FromRoute]int id)
        {
            var recipe = _recipeDbContext
                .Recipes
                .Include(r=>r.RecipeInstructions)
                .Include(r => r.RecipeIngredientParts)
                .Include(r=>r.RecipeIngredientQuantities)
                .Include(r=>r.Images)
                .Include(r => r.Keywords)
                .FirstOrDefault(r=>r.RecipeId==id);
           
            if (recipe==null)
            {
                return NotFound();
            }
            var recipeDto=_mapper.Map<RecipeDto>(recipe);
            return Ok(recipeDto);
        }

        // POST api/<RecipeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
