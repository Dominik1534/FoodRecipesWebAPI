using System.ComponentModel.DataAnnotations;

namespace FoodRecipesWebAPI.Entities
{
    public class Reviews
    {
        [Key]
        public string? ReviewId { get; set; }
        public string? RecipeId { get; set; }
        public string? AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? Rating { get; set; }
        public string? Review { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public DateTime? DateModified { get; set; }       
        public virtual Recipes? Recipes { get; set; }


    }
}