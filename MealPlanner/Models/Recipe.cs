using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Recipe
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Recipe()
        {
            Id= Guid.NewGuid().ToString();
        }
    }
}
