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
        [HttpGet()]
        public IEnumerable<RecipeDto> GetRecipes()
        {

            var recipeDto = _recipeServices.GetRecipes();
            return recipeDto;
        }
        [HttpGet("{id}")]
        public ActionResult<RecipeDto> GetRecipeById([FromRoute] int id)
        {
            var recipeDTO = _recipeServices.GetRecipeByID(id);

            return Ok(recipeDTO);
        }
        
        [HttpGet("keyword/{keyword}")]
        public IEnumerable<RecipeDto> GetRecipeByKeywords(string keyword)
        {

            var recipeDto = _recipeServices.GetRecipeByKeywords(keyword);
            return recipeDto;
        }



        [HttpGet("ingredient/{ingredient}")]
        public IEnumerable<RecipeDto> GetRecipeByIngridnient(string ingredient)
        {

            var recipeDto = _recipeServices.GetRecipeByRecipeIngredientParts(ingredient);
            return recipeDto;
        }

        [HttpGet("category/{category}")]
        public IEnumerable<RecipeDto> GetRecipeByCategory(string category)
        {

            var recipeDto = _recipeServices.GetRecipeByRecipeRecipeCategory(category);
            return recipeDto;
        }
    }
}
