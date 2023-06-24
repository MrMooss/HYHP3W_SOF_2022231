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
        public string MealId { get; set; }
        [NotMapped]
        public virtual Meal Meal { get; set; }
        public Recipe()
        {
            Id= Guid.NewGuid().ToString();
        }
    }
}
