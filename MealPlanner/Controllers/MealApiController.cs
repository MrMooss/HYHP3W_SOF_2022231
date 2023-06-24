using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Meal> Get()
        {
            return meals;
        }

        static List<Meal> meals = new List<Meal>
        {
            new Meal(){Name = "name", ConsumptionDate = DateTime.Now, Description="asd", Recipe = new Recipe() { Description = "asdasd", Name="name recept" } },
        };

        [HttpPost]
        public void AddMeal([FromBody] Meal m)
        {
            m.Id = Guid.NewGuid().ToString();
            meals.Add(m);
        }

        [HttpPut]
        public void EditMeal([FromBody] Meal m)
        {
            var old = meals.FirstOrDefault(t => t.Id == m.Id);
            old.Name = m.Name;
            old.Description = m.Description;
            old.Recipe = m.Recipe;
            old.ConsumptionDate = m.ConsumptionDate;
            old.ImageUrl = m.ImageUrl;
            old.MealType = m.MealType;
        }

        [HttpDelete("{id}")]
        public void DeleteMeal(string id)
        {
            var mealToDelete = meals.FirstOrDefault(t => t.Id == id);
            meals.Remove(mealToDelete);
        }

    }
}
