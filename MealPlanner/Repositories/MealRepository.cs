using MealPlanner.Data;
using MealPlanner.Interfaces;
using MealPlanner.Models;

namespace MealPlanner.Repositories
{
    public class MealRepository : RepositoryBase<Meal, string>, IMealRepository
    {
        public MealRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Meal Read(string id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
