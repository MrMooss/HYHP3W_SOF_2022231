using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Meal> Index()
        {
            return null;
        }
    }
}
