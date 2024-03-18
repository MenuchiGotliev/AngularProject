using Microsoft.AspNetCore.Mvc;
using projestSwagger.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projestSwagger.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class RecipeController : ControllerBase
    {

        static List<Recipe> recipes = new List<Recipe>()
        {
             new Recipe
            {
              RecipeId = 0,
  RecipeName = "עוגת שוקולד",
  CategoryId = 1,
  PreparationTime = 45,
  DifficultyLevel = 5,
  DateAdded = DateTime.Now,
  Ingredients = new List<string> { "קמח", "סוכר", "קקאו", "ביצים", "אבקת אפיה","שוקולד" ,"שמן"},
  PreparationSteps = new List<string> { "ערבבי את הקמח וא. אפיה",
      "הוסיפי את שאר המרכיבים מלבד השוקולד והשמן",
      "אפי כ- 30 דקות בתנור שחומם מראש ל-180°",
      "המיסי שוקולד ושמן בסיר","" +
      "שפכי על העוגה בעודה חמה" },
  UserId = 1,
  ImageRouting = "./../../../assets/images/cake-6313427_1280.jpg"
            },
        new Recipe
            {
                RecipeId = 1,
                RecipeName = "Chocolate Cake",
                CategoryId = 1,
                PreparationTime = 45,
                DifficultyLevel = 1,
                DateAdded = DateTime.Now,
                Ingredients = new List<string> { "Flour", "Sugar", "Cocoa Powder", "Eggs", "Milk" },
                PreparationSteps = new List<string> { "Preheat oven to 350°F", "Mix dry ingredients", "Add wet ingredients", "Bake for 30 minutes" },
                UserId = 1,
                ImageRouting = "../../../../assets/images/cake-6292573_1280 (1).jpg"

            },new Recipe
          {
                 RecipeId = 2,
                 RecipeName = "Chocolate Cake",
                 CategoryId = 1,
                 PreparationTime = 45,
                 DifficultyLevel = 1,
                 DateAdded = DateTime.Now,
                 Ingredients = new List<string> { "Flour", "Sugar", "Cocoa Powder", "Eggs", "Milk" },
                 PreparationSteps = new List<string> { "Preheat oven to 350°F", "Mix dry ingredients", "Add wet ingredients", "Bake for 30 minutes" },
                 UserId = 1,
                 ImageRouting = "./../../../assets/images/chocolate-1220655_1280.jpg"


               },
             new Recipe
            {
                RecipeId = 3,
                RecipeName = "Chocolate Cake",
                CategoryId = 1,
                PreparationTime = 45,
                DifficultyLevel = 1,
                DateAdded = DateTime.Now,
                Ingredients = new List<string> { "Flour", "Sugar", "Cocoa Powder", "Eggs", "Milk" },
                PreparationSteps = new List<string> { "Preheat oven to 350°F", "Mix dry ingredients", "Add wet ingredients", "Bake for 30 minutes" },
                UserId = 1,
                ImageRouting = "../../../../assets/images/meringue-813929_1280.jpg"

            },new Recipe
          {
                 RecipeId = 4,
                 RecipeName = "Chocolate Cake",
                 CategoryId = 1,
                 PreparationTime = 45,
                 DifficultyLevel = 1,
                 DateAdded = DateTime.Now,
                 Ingredients = new List<string> { "Flour", "Sugar", "Cocoa Powder", "Eggs", "Milk" },
                 PreparationSteps = new List<string> { "Preheat oven to 350°F", "Mix dry ingredients", "Add wet ingredients", "Bake for 30 minutes" },
                 UserId = 1,
                 ImageRouting = "../../../../assets/images/chocolate-candy-182861_1280.jpg"


               }
            ,new Recipe
          {
                 RecipeId = 5,
                 RecipeName = "Chocolate Cake",
                 CategoryId = 1,
                 PreparationTime = 45,
                 DifficultyLevel = 1,
                 DateAdded = DateTime.Now,
                 Ingredients = new List<string> { "Flour", "Sugar", "Cocoa Powder", "Eggs", "Milk" },
                 PreparationSteps = new List<string> { "Preheat oven to 350°F", "Mix dry ingredients", "Add wet ingredients", "Bake for 30 minutes" },
                 UserId = 1,
                 ImageRouting = "\"../../../../assets/images/cake-5842067_1280.jpg"


               }
        }
    ;
        static int count = recipes.Count() + 1;


        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return recipes;
        }

        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            var recipe = recipes.Find(r => r.RecipeId == id);
            return recipe;
        }




        [HttpPost]
        public void Post([FromBody] Recipe recipe)
        {
            recipe.RecipeId = count++;
            recipe.DateAdded = DateTime.Now;
            recipes.Add(recipe);

        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Recipe updatedRecipe)
        {
            var recipe = recipes.Find(r => r.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            recipe.RecipeName = updatedRecipe.RecipeName;
            recipe.CategoryId = updatedRecipe.CategoryId;
            recipe.PreparationTime = updatedRecipe.PreparationTime;
            recipe.DifficultyLevel = updatedRecipe.DifficultyLevel;
            recipe.Ingredients = updatedRecipe.Ingredients;
            recipe.PreparationSteps = updatedRecipe.PreparationSteps;
            recipe.UserId = updatedRecipe.UserId;
            recipe.ImageRouting = updatedRecipe.ImageRouting;
            return NoContent();

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var recipe = recipes.Find(r => r.RecipeId == id);
            if (recipe != null)
            {
                recipes.Remove(recipe);
            }
        }

    }
}
