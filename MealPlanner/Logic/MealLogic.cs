using MealPlanner.Interfaces;
using MealPlanner.Models;

namespace MealPlanner.Logic
{
    public class MealLogic : IMealLogic
    {
        IMealRepository _mealRepository;
        IRecipeRepository _recipeRepository;

        public MealLogic(IMealRepository mealRepository, IRecipeRepository recipeRepository)
        {
            _mealRepository = mealRepository;
            _recipeRepository = recipeRepository;
        }

        public Meal Create(Meal entity)
        {
            if (entity != null)
            {
                var res = _mealRepository.Read(entity.Id);
                if (res == null)
                {
                    var result = _mealRepository.Create(entity);
                    return result;
                }
                else
                {
                    throw new Exception("Meal already exists!");
                }
            }
            else
            {
                throw new Exception("Must contain the required data!");
            }
        }

        public void Delete(string id)
        {
            var res = _mealRepository.Read(id);
            if (res != null)
            {
                _mealRepository.Delete(id);
            }
            else
            {
                throw new Exception("Meal not found!");
            }
        }

        public Meal Read(string id)
        {
            return _mealRepository.Read(id);
        }

        public IList<Meal> ReadAll()
        {
            return _mealRepository.ReadAll().ToList();
        }

        public Meal Update(Meal entity)
        {
            if (entity != null)
            {
                var res = _mealRepository.Read(entity.Id);
                if (res != null)
                {
                    res.Owner = res.Owner;
                    res.Description = entity.Description;
                    res.Name = entity.Name;
                    res.ConsumptionDate = entity.ConsumptionDate;
                    res.MealType = entity.MealType;
                    res.Recipe = entity.Recipe;
                    res.ImageUrl = entity.ImageUrl;

                    var result = _mealRepository.Update(res);
                    return result;
                }
                else
                {
                    throw new Exception("Meal not found!");
                }
            }
            else
            {
                throw new Exception("Must contain the required data!");
            }
        }
    }
}
