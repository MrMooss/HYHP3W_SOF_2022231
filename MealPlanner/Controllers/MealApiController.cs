using Common.DTOs;
using MealPlanner.Interfaces;
using MealPlanner.Logic;
using MealPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealApiController : ControllerBase
    {
        private readonly IMealLogic mealLogic;
        private readonly IRecipeLogic recipeLogic;

        public MealApiController(IMealLogic mealLogic, IRecipeLogic recipeLogic)
        {
            this.mealLogic = mealLogic;
            this.recipeLogic = recipeLogic;
        }

        [HttpGet]
        public IEnumerable<MealDTO> GetAllMeals()
        {

            IList<Meal> meals = mealLogic.ReadAll();
            IList<MealDTO> mealDTOs = MapMealsToDTOs(meals);
            return mealDTOs;
        }

        [HttpGet("{id}")]
        public MealDTO? GetMeal(string id)
        {

            Meal meal = mealLogic.Read(id);
            MealDTO mealDTO = MapMealToDTO(meal);
            return mealDTO;

        }

        [HttpPost]
        public void CreateMeal([FromBody] MealDTO mealDTO)
        {
            Meal meal = MapDTOToMeal(mealDTO);
            Meal createdMeal = mealLogic.Create(meal);
        }

        [HttpPut("{id}")]
        public void UpdateMeal([FromBody] UpdateMealDTO mealDTO)
        {
            Meal existingMeal = mealLogic.Read(mealDTO.Id);
            Meal updatedMeal = MapDTOToMeal(mealDTO, existingMeal);
            mealLogic.Update(updatedMeal);
        }

        [HttpDelete("{id}")]
        public void DeleteMeal(string id)
        {
                mealLogic.Delete(id);
        }

        private IList<MealDTO> MapMealsToDTOs(IList<Meal> meals)
        {
            List<MealDTO> mealDTOs = new List<MealDTO>();
            foreach (Meal meal in meals)
            {
                mealDTOs.Add(MapMealToDTO(meal));
            }
            return mealDTOs;
        }

        private MealDTO MapMealToDTO(Meal meal)
        {
            return new MealDTO
            {
                Id = meal.Id,
                Name = meal.Name,
                Description = meal.Description,
                ImageUrl = meal.ImageUrl,
                ConsumptionDate = meal.ConsumptionDate,
                MealType = meal.MealType,
                Recipe = MapRecipeToDTO(meal.Recipe)
            };
        }

        private RecipeDTO MapRecipeToDTO(Recipe recipe)
        {
            return new RecipeDTO
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description
            };
        }

        private Meal MapDTOToMeal(MealDTO mealDTO, Meal existingMeal = null)
        {
            Meal meal = existingMeal ?? new Meal();
            meal.Id = mealDTO.Id;
            meal.Name = mealDTO.Name;
            meal.Description = mealDTO.Description;
            meal.ImageUrl = mealDTO.ImageUrl;
            meal.ConsumptionDate = mealDTO.ConsumptionDate;
            meal.MealType = mealDTO.MealType;
            meal.Recipe = MapDTOToRecipe(mealDTO.Recipe, meal.Recipe);
            return meal;
        }

        private Recipe MapDTOToRecipe(RecipeDTO recipeDTO, Recipe existingRecipe = null)
        {
            Recipe recipe = existingRecipe ?? new Recipe();
            recipe.Id = recipeDTO.Id;
            recipe.Name = recipeDTO.Name;
            recipe.Description = recipeDTO.Description;
            return recipe;
        }

    }
}
