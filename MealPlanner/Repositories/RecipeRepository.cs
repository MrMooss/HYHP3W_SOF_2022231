using MealPlanner.Data;
using MealPlanner.Interfaces;
using MealPlanner.Models;

namespace MealPlanner.Repositories
{
    public class RecipeRepository : RepositoryBase<Recipe, string>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override Recipe Read(string id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
