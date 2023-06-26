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
        public IActionResult GetAllMeals()
        {
            try
            {
                IList<Meal> meals = mealLogic.ReadAll();
                IList<MealDTO> mealDTOs = MapMealsToDTOs(meals);
                return Ok(mealDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMeal(string id)
        {
            try
            {
                Meal meal = mealLogic.Read(id);
                if (meal == null)
                {
                    return NotFound();
                }
                MealDTO mealDTO = MapMealToDTO(meal);
                return Ok(mealDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateMeal(MealDTO mealDTO)
        {
            try
            {
                Meal meal = MapDTOToMeal(mealDTO);
                Meal createdMeal = mealLogic.Create(meal);
                MealDTO createdMealDTO = MapMealToDTO(createdMeal);
                return CreatedAtAction(nameof(GetMeal), new { id = createdMealDTO.Id }, createdMealDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeal(string id, MealDTO mealDTO)
        {
            try
            {
                if (id != mealDTO.Id)
                {
                    return BadRequest("Invalid ID");
                }
                Meal existingMeal = mealLogic.Read(id);
                if (existingMeal == null)
                {
                    return NotFound();
                }
                Meal updatedMeal = MapDTOToMeal(mealDTO, existingMeal);
                mealLogic.Update(updatedMeal);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeal(string id)
        {
            try
            {
                Meal existingMeal = mealLogic.Read(id);
                if (existingMeal == null)
                {
                    return NotFound();
                }
                mealLogic.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
