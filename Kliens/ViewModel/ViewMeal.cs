using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliens.ViewModel
{
    public class ViewMeal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public MealType MealType { get; set; }
        public string RecipeID { get; set; }
        public string RecipeDescription { get; set;}
    }
}
