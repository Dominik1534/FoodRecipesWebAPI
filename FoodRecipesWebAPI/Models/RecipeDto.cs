using FoodRecipesWebAPI.Entities;

namespace FoodRecipesWebAPI.Models
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string? Name { get; set; }      
        public string? AuthorName { get; set; }
        public string? CookTime { get; set; }
        public string? PrepTime { get; set; }
        public string? TotalTime { get; set; }
        public DateTime? DatePublished { get; set; }
        public string? Description { get; set; }
        public List<ImagesDto>? Images { get; set; }
        public string? RecipeCategory { get; set; }
        public List<KeywordsDto>? Keywords { get; set; }
        public List<RecipeIngredientQuantitiesDto>? RecipeIngredientQuantities { get; set; }
        public List<RecipeIngredientsPartsDto>? RecipeIngredientParts { get; set; }
        public string? AggregatedRating { get; set; }
        public string? ReviewCount { get; set; }
        public float? Calories { get; set; }
        public float? FatContent { get; set; }
        public float? CholesterolContent { get; set; }
        public float? SodiumContent { get; set; }
        public float? CarbohydrateContent { get; set; }
        public float? FiberContent { get; set; }
        public float? SugarContent { get; set; }
        public float? ProteinContent { get; set; }
        public string? RecipeServings { get; set; }
        public string? RecipeYield { get; set; }
        public List<RecipeInstructionsDto>? RecipeInstructions { get; set; }
    }
}
