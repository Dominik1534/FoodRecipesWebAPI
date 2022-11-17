using AutoMapper;
using FoodRecipesWebAPI.Entities;
using FoodRecipesWebAPI.Exceptions;
using FoodRecipesWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodRecipesWebAPI.Services
{
    public interface IRecipeServices
    { 
        IEnumerable<RecipeDto> GetRecipes();    
        RecipeDto GetRecipeByID(int id);
        IEnumerable<RecipeDto> GetRecipeByKeywords(string keyword);
        IEnumerable<RecipeDto> GetRecipeByRecipeIngredientParts(string ingredientParts);
        IEnumerable<RecipeDto> GetRecipeByRecipeRecipeCategory(string recipeCategory);
    }
    public class RecipeServices: IRecipeServices
    {
        private readonly RecipeDbContext _recipeDbContext;
        private readonly IMapper _mapper;

      

        public RecipeServices(RecipeDbContext recipeDbContext, IMapper mapper)
        {
           _recipeDbContext = recipeDbContext;
           _mapper=mapper;

        }
        public IEnumerable<RecipeDto> GetRecipes()
        {


            var recipe = _recipeDbContext
                .Recipes
                .Include(r => r.RecipeInstructions)
                .Include(r => r.RecipeIngredientParts)
                .Include(r => r.RecipeIngredientQuantities)
                .Include(r => r.Images)
                .Include(r => r.Keywords)               
                .Take(10)
                .ToList();


            if (recipe is null)
                throw new NotFoundException("Keyword not found");


            var recipeDto = _mapper.Map<List<RecipeDto>>(recipe);

            return recipeDto;
        }
        public RecipeDto GetRecipeByID(int id)
        {
            var recipe = _recipeDbContext
                .Recipes
                .Include(r => r.RecipeInstructions)
                .Include(r => r.RecipeIngredientParts)
                .Include(r => r.RecipeIngredientQuantities)
                .Include(r => r.Images)
                .Include(r => r.Keywords)
                .FirstOrDefault(r => r.RecipeId == id);

            if (recipe is null)
                throw new NotFoundException("Restaurant not found");

            var recipeDto = _mapper.Map<RecipeDto>(recipe);

            return recipeDto;
        }
        public IEnumerable<RecipeDto> GetRecipeByKeywords(string keyword)
        {


            var recipe = _recipeDbContext
                .Recipes
                .Include(r => r.RecipeInstructions)
                .Include(r => r.RecipeIngredientParts)
                .Include(r => r.RecipeIngredientQuantities)
                .Include(r => r.Images)
                .Include(r => r.Keywords)
                .Where(r => r.Keywords.Any(b => b.Keyword.ToLower() == keyword.ToLower()))
                .Take(10)
                .ToList();


            if (recipe is null)
                throw new NotFoundException("Keyword not found");


            var recipeDto = _mapper.Map<List<RecipeDto>>(recipe);

            return recipeDto;
        }
        public IEnumerable<RecipeDto> GetRecipeByRecipeIngredientParts(string ingredientParts)
        {

            var recipe = _recipeDbContext
                .Recipes
                .Include(r => r.RecipeInstructions)
                .Include(r => r.RecipeIngredientParts)
                .Include(r => r.RecipeIngredientQuantities)
                .Include(r => r.Images)
                .Include(r => r.Keywords)
                .Where(r => r.RecipeIngredientParts.Any(b => b.RecipeIngredientPart.ToLower() == ingredientParts.ToLower()))
                .Take(10)
                .ToList();


            if (recipe is null)
                throw new NotFoundException("Keyword not found");


            var recipeDto = _mapper.Map<List<RecipeDto>>(recipe);

            return recipeDto;
        }
        public IEnumerable<RecipeDto> GetRecipeByRecipeRecipeCategory(string recipeCategory)
        {

            var recipe = _recipeDbContext
                .Recipes
                .Include(r => r.RecipeInstructions)
                .Include(r => r.RecipeIngredientParts)
                .Include(r => r.RecipeIngredientQuantities)
                .Include(r => r.Images)
                .Include(r => r.Keywords)
                .Where(r => r.RecipeCategory.ToLower()==recipeCategory.ToLower())
                .Take(10)
                .ToList();


            if (recipe is null)
                throw new NotFoundException("Keyword not found");


            var recipeDto = _mapper.Map<List<RecipeDto>>(recipe);

            return recipeDto;
        }
    }
}
