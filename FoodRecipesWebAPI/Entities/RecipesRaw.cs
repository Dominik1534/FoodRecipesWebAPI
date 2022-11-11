namespace FoodRecipesWebAPI.Entities
{
    public class RecipesRaw
    {
        public int RecipeId { get; set; }
        public string? Name { get; set; }
        public string? AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? CookTime { get; set; }
        public string? PrepTime { get; set; }
        public string? TotalTime { get; set; }
        public DateTime? DatePublished { get; set; }
        public string? Description { get; set; }
        public string Images { get; set; }
        public string? RecipeCategory { get; set; }
        public string Keywords { get; set; }
        public string RecipeIngredientQuantities { get; set; }
        public string RecipeIngredientParts { get; set; }
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
        public string RecipeInstructions { get; set; }
    }
}
