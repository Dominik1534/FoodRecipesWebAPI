using AutoMapper;
using FoodRecipesWebAPI.Entities;
using FoodRecipesWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static FoodRecipesWebAPI.Services.RecipeServices;
using FoodRecipesWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodRecipesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeServices _recipeServices;
        
        public RecipeController(IRecipeServices recipeServices ) 
        {
           _recipeServices= recipeServices;
        }

        // GET: api/<RecipeController>

        //[HttpGet("{id}")]
        //public ActionResult<RecipeDto> Get([FromRoute] int id)
        //{    
        //    var recipeDTO = _recipeServices.GetRecipeByID(id);
           
        //    return Ok(recipeDTO);
        //}
        [HttpGet("{keyword}")]
        public IEnumerable<RecipeDto> GetRecipeByKeywords(string keyword)
        {


            //var recipe = _recipeDbContext
            //    .Recipes
            //    .Include(r => r.RecipeInstructions)
            //    .Include(r => r.RecipeIngredientParts)
            //    .Include(r => r.RecipeIngredientQuantities)
            //    .Include(r => r.Images)
            //    .Include(r => r.Keywords)
            //    .Where(r => r.Keywords.Any(b => b.Keyword.ToLower() == keyword.ToLower())) 
            //    .Take(10)
            //    .ToList();


            //if (recipe is null)
            //{
            //    return null;
            //}

            //var recipeDto = _mapper.Map<List<RecipeDto>>(recipe);
            var recipeDto = _recipeServices.GetRecipeByKeywords(keyword);
            return recipeDto;
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
