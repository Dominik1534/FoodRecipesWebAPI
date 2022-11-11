using CsvHelper;
using FoodRecipesWebAPI.Entities;
using System.Globalization;

namespace FoodRecipesWebAPI
{
    public class FoodSeeder
    {
        private readonly RecipeDbContext _dbContext;
        public FoodSeeder(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public void Seed()
        {

            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Recipes.Any())
                {
                    var recipes = GetRecipes();
                    int count = 0;
                    int count2 = 0;
                    int value = (int)(recipes.Count() * 0.01);
                    foreach (var recipe in recipes)
                    {
                        count++;
                        _dbContext.Add(recipe);
                        if (count % value == 0)
                        {
                            _dbContext.SaveChanges();
                            count2++;
                            Console.WriteLine(count2);
                        }
                        if (recipes.Last() == recipe)
                        {
                            _dbContext.SaveChanges();
                        }
                    }
                }
                if (!_dbContext.Reviews.Any())
                {
                    var recipes = GetRevievs();
                    int count = 0;
                    int count2 = 0;
                    int value = (int)(recipes.Count() * 0.01);
                    foreach (var recipe in recipes)
                    {
                        count++;
                        _dbContext.Add(recipe);
                        if (count % value == 0)
                        {
                            _dbContext.SaveChanges();
                            count2++;
                            Console.WriteLine(count2);
                        }
                        if (recipes.Last() == recipe)
                        {
                            _dbContext.SaveChanges();
                        }
                    }
                }
            }
        }

        private IEnumerable<Reviews> GetRevievs()
        {
            using (var reader = new StreamReader("reviews.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();

                List<Reviews> reviews = new List<Reviews>();
                foreach (var record in records)
                {
                    reviews.Add(new Reviews()
                    {


                        ReviewId = record.ReviewId,
                        AuthorId = record.AuthorId,
                        AuthorName = record.AuthorName,
                        Rating = record.Rating,
                        Review = record.Review,
                        DateSubmitted = DateTime.Parse(record.DateSubmitted),
                        DateModified = DateTime.Parse(record.DateModified),



                    });
                }
                return reviews;
            }
        }

        private IEnumerable<Recipes> GetRecipes()
        {
            using (var reader = new StreamReader("recipes.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                char[] charsToTrim = { 'c', '(', ')' };
                var records = csv.GetRecords<RecipesRaw>();
                List<Recipes> recipes = new List<Recipes>();
                int z = 0;

                foreach (var item in records)
                {

                    z++;
                    var imagesRaw = item.Images.Trim(charsToTrim);
                    string[] images = imagesRaw.Split('"');

                    List<Images> image = new List<Images>();

                    for (int b = 0; b < images.Length; b++)
                    {
                        if (images[b].Contains("http"))
                        {
                            image.Add(new Images()
                            {
                                Image = images[b],
                                Recipe = item.RecipeId,
                            });
                        }
                    }

                    var keywordsRaw = item.Keywords.Trim(charsToTrim);
                    string[] keywords = keywordsRaw.Split(',');
                    List<Keywords> keywordsList = new List<Keywords>();

                    for (int b = 0; b < keywords.Length; b++)
                    {

                        keywordsList.Add(new Keywords()
                        {
                            Keyword = keywords[b].Replace("\"", ""),
                            Recipe = item.RecipeId,
                        });

                    }

                    var recipeIngredientQuantitiesRaw = item.RecipeIngredientQuantities.Trim(charsToTrim);
                    string[] recipeIngredientQuantities = recipeIngredientQuantitiesRaw.Split(',');
                    List<RecipeIngredientQuantities> recipeIngredientQuantitiesList = new List<RecipeIngredientQuantities>();

                    for (int b = 0; b < recipeIngredientQuantities.Length; b++)
                    {

                        recipeIngredientQuantitiesList.Add(new RecipeIngredientQuantities()
                        {
                            RecipeIngredientQuantitie = recipeIngredientQuantities[b].Replace("\"", ""),
                            Recipe = item.RecipeId,
                        });

                    }

                    var recipeIngredientPartsRaw = item.RecipeIngredientParts.Trim(charsToTrim);
                    string[] recipeIngredientParts = recipeIngredientPartsRaw.Split(',');
                    List<RecipeIngredientParts> recipeIngredientPartsList = new List<RecipeIngredientParts>();

                    for (int b = 0; b < recipeIngredientParts.Length; b++)
                    {

                        recipeIngredientPartsList.Add(new RecipeIngredientParts()
                        {
                            RecipeIngredientPart = recipeIngredientParts[b].Replace("\"", ""),
                            Recipe = item.RecipeId,
                        });

                    }


                    var recipeInstructionsRaw = item.RecipeInstructions.Trim(charsToTrim);
                    string[] recipeInstructions = recipeInstructionsRaw.Split(',');
                    List<RecipeInstructions> recipeInstructionsList = new List<RecipeInstructions>();

                    for (int b = 0; b < recipeInstructions.Length; b++)
                    {

                        recipeInstructionsList.Add(new RecipeInstructions()
                        {
                            RecipeInstruction = recipeInstructions[b].Replace("\"", ""),
                            Recipe = item.RecipeId,
                        });
                    }


                    recipes.Add(new Recipes()
                    {
                        RecipeId = item.RecipeId,
                        Name = item.Name,
                        AuthorId = item.AuthorId,
                        AuthorName = item.AuthorName,
                        CookTime = item.CookTime,
                        PrepTime = item.PrepTime,
                        TotalTime = item.TotalTime,
                        DatePublished = item.DatePublished,
                        Description = item.Description,
                        Images = image,
                        RecipeCategory = item.RecipeCategory,
                        Keywords = keywordsList,
                        RecipeIngredientQuantities = recipeIngredientQuantitiesList,
                        RecipeIngredientParts = recipeIngredientPartsList,
                        AggregatedRating = item.AggregatedRating,
                        ReviewCount = item.ReviewCount,
                        Calories = item.Calories,
                        FatContent = item.FatContent,
                        CholesterolContent = item.CholesterolContent,
                        SodiumContent = item.SodiumContent,
                        CarbohydrateContent = item.CarbohydrateContent,
                        FiberContent = item.FiberContent,
                        SugarContent = item.SugarContent,
                        ProteinContent = item.ProteinContent,
                        RecipeServings = item.RecipeServings,
                        RecipeYield = item.RecipeYield,
                        RecipeInstructions = recipeInstructionsList,

                    });


                }

                return recipes;

            }
        }
    }
}
