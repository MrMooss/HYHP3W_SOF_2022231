using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models
{
    public class Recipe
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public Meal Meal { get; set; }
        public Recipe()
        {
            Id= Guid.NewGuid().ToString();
        }
    }
}
