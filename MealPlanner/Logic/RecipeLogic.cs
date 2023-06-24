using MealPlanner.Interfaces;
using MealPlanner.Models;

namespace MealPlanner.Logic
{
    public class RecipeLogic : IRecipeLogic
    {
        IMealRepository _mealRepository;
        IRecipeRepository _recipeRepository;

        public RecipeLogic(IMealRepository mealRepository, IRecipeRepository recipeRepository)
        {
            _mealRepository = mealRepository;
            _recipeRepository = recipeRepository;
        }
        public Recipe Create(Recipe entity)
        {
            if (entity != null)
            {
                var res = _recipeRepository.Read(entity.Id);
                if (res == null)
                {
                    var result = _recipeRepository.Create(entity);
                    return result;
                }
                else
                {
                    throw new Exception("Recipe already exists!");
                }
            }
            else
            {
                throw new Exception("Must contain the required data!");
            }
        }

        public void Delete(string id)
        {
            var res = _recipeRepository.Read(id);
            if (res != null)
            {
                _recipeRepository.Delete(id);
            }
            else
            {
                throw new Exception("Recipe not found!");
            }
        }

        public Recipe Read(string id)
        {
            return _recipeRepository.Read(id);
        }

        public IList<Recipe> ReadAll()
        {
            return _recipeRepository.ReadAll().ToList();
        }

        public Recipe Update(Recipe entity)
        {
            if (entity != null)
            {
                var res = _recipeRepository.Read(entity.Id);
                if (res != null)
                {
                    res.Description = entity.Description;
                    res.Meal = entity.Meal;
                    res.Name = entity.Name;

                    var result = _recipeRepository.Update(res);
                    return result;
                }
                else
                {
                    throw new Exception("Recipe not found!");
                }
            }
            else
            {
                throw new Exception("Must contain the required data!");
            }
        }
    }
}
