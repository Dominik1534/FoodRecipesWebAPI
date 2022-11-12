using AutoMapper;
using FoodRecipesWebAPI.Entities;
using FoodRecipesWebAPI.Models;

namespace FoodRecipesWebAPI
{
    public class RecipeMappingProfile : Profile
    {
        public RecipeMappingProfile()
        {
            CreateMap<Recipes, RecipeDto>();
            CreateMap<Images, ImagesDto>();
            CreateMap<Keywords, KeywordsDto>();
            CreateMap<RecipeInstructions, RecipeInstructionsDto>();
            CreateMap<RecipeIngredientParts, RecipeIngredientsPartsDto>();
            CreateMap<RecipeIngredientQuantities, RecipeIngredientQuantitiesDto>();


        }
    }
}
