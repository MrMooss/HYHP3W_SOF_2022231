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
            Recipe recipe = new Recipe
            {
                Name = mealDTO.Name,
                Description = mealDTO.RecipeDescription,
                Meal = meal
            };
            meal.Recipe = recipe;

            mealLogic.Create(meal);
            recipeLogic.Create(recipe);
        }

        [HttpPut]
        public void UpdateMeal([FromBody] MealDTO mealDTO)
        {
            Meal existingMeal = mealLogic.Read(mealDTO.Id);
            Meal updatedMeal = MapDTOToMeal(mealDTO, existingMeal);
            Recipe existingRecipe = recipeLogic.Read(existingMeal.Recipe.Id);
            Recipe updatedRecipe = MapDTOToRecipe(mealDTO, existingRecipe, existingMeal);

            mealLogic.Update(updatedMeal);
            recipeLogic.Update(updatedRecipe);
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
                Name = meal.Name,
                Description = meal.Description,
                ImageUrl = meal.ImageUrl,
                ConsumptionDate = meal.ConsumptionDate,
                MealType = meal.MealType,
                RecipeDescription = meal.Recipe?.Description
            };
        }

        private Meal MapDTOToMeal(MealDTO mealDTO, Meal existingMeal = null)
        {
            Meal meal = existingMeal ?? new Meal();
            meal.Name = mealDTO.Name;
            meal.Description = mealDTO.Description;
            meal.ImageUrl = mealDTO.ImageUrl;
            meal.ConsumptionDate = mealDTO.ConsumptionDate;
            meal.MealType = mealDTO.MealType;
            return meal;
        }

        private Recipe MapDTOToRecipe(MealDTO mealDTO, Recipe existingRecipe = null, Meal existingMeal = null)
        {
            Recipe recipe = existingRecipe ?? new Recipe();
            recipe.Name = mealDTO.Name;
            recipe.Description = mealDTO.RecipeDescription;
            recipe.Meal = existingMeal;
            return recipe;
        }
    }
}
