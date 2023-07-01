using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class UpdateMealDTO
    {
        public string Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; }
        [Required]
        [StringLength(10000, ErrorMessage = "Name length can't be more than 10000.")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public DateTime ConsumptionDate { get; set; }
        [Required]
        public MealType MealType { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string RecipeName { get; set; }
        [Required]
        [StringLength(10000, ErrorMessage = "Name length can't be more than 10000.")]
        public string RecipeDescription { get; set; }
    }
}
