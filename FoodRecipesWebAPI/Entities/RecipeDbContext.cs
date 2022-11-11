using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FoodRecipesWebAPI.Entities
{

    public class RecipeDbContext : DbContext       
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options): base(options)
        {
           
        }
        //private string _connectionString = "Server=DESKTOP-2E2M676;Database=FoodDatabase3;Trusted_Connection=True;MultipleActiveResultSets=true";
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Reviews>? Reviews { get; set; }
        public DbSet<Images>? Images { get; set; }
        public DbSet<Keywords>? Keywords { get; set; }
        public DbSet<RecipeIngredientQuantities>? RecipeIngredientQuantities { get; set; }
        public DbSet<RecipeIngredientParts>? RecipeIngredientParts { get; set; }
        public DbSet<RecipeInstructions>? RecipeInstructions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }

}
