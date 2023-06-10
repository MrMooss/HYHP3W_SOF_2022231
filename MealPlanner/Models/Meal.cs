using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Meal
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public MealType MealType { get; set; }
        public Meal()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
