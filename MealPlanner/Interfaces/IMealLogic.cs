using MealPlanner.Models;

namespace MealPlanner.Interfaces
{
    public interface IMealLogic
    {
        IList<Meal> ReadAll();
        Meal Read(string id);
        Meal Create(Meal entity);
        Meal Update(Meal entity);
        void Delete(string id);
    }
}
