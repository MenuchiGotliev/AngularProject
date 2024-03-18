namespace projestSwagger.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int CategoryId { get; set; }
        public int PreparationTime { get; set; }
        public int DifficultyLevel { get; set; }
        public DateTime DateAdded { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> PreparationSteps { get; set; }
        public int UserId { get; set; }
        public string ImageRouting { get; set; }
    }
}
 