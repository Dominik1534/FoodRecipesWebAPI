using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodRecipesWebAPI.Entities
{
    public class Recipes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecipeId { get; set; }
        public string? Name { get; set; }
        public string? AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? CookTime { get; set; }
        public string? PrepTime { get; set; }
        public string? TotalTime { get; set; }
        public DateTime? DatePublished { get; set; }
        public string? Description { get; set; }
        public List<Images>? Images { get; set; }
        public string? RecipeCategory { get; set; }
        public List<Keywords>? Keywords { get; set; }
        public List<RecipeIngredientQuantities>? RecipeIngredientQuantities { get; set; }
        public List<RecipeIngredientParts>? RecipeIngredientParts { get; set; }
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
        public List<RecipeInstructions>? RecipeInstructions { get; set; }
       
        

    }

    public class RecipeInstructions
    {
        public int Id { get; set; }
        public string? RecipeInstruction { get; set; }
        public int Recipe { get; set; }
       
    }

    public class RecipeIngredientParts
    {
        public int Id { get; set; }
        public string? RecipeIngredientPart { get; set; }
        public int Recipe { get; set; }
        
    }

    public class RecipeIngredientQuantities
    {
        public int Id { get; set; }
        public string? RecipeIngredientQuantitie { get; set; }
        public int Recipe { get; set; }
       
    }

    public class Keywords
    {
        public int Id { get; set; }
        public string? Keyword { get; set; }
        public int Recipe { get; set; }
        
    }

    public class Images
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public int Recipe { get; set; }
      
    }
}
