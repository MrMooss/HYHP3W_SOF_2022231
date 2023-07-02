using MealPlanner.Models;

namespace MealPlanner.Interfaces
{
    public interface IRecipeLogic
    {
        IList<Recipe> ReadAll();
        Recipe Read(string id);
        Recipe Create(Recipe entity);
        Recipe Update(Recipe entity);
        void Delete(string id);
    }
}
