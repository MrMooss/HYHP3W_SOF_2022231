using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kliens.ViewModel
{
    class ViewMeal
    {
        private string name;
        private string description;
        private string imageUrl;
        private DateTime consumptionDate;
        private ViewRecipe recipe;
        private MealType mealType;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public DateTime ConsumptionDate { get => consumptionDate; set => consumptionDate = value; }
        public MealType MealType { get => mealType; set => mealType = value; }
        public virtual ViewRecipe Recipe { get => recipe; set => recipe = value; }
    }
}
