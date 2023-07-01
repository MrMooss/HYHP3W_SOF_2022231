using Common.DTOs;
using MealPlanner.Interfaces;
using MealPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MealPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMealLogic _mealLogic;
        private readonly IRecipeLogic _recipeLogic;

        public HomeController(ILogger<HomeController> logger, UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager, IMealLogic mealLogic, IRecipeLogic recipeLogic)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _mealLogic = mealLogic;
            _recipeLogic = recipeLogic;
        }

        public IActionResult Index()
        {
            return View(_mealLogic.ReadAll());
        }

        [Authorize(Roles = "NormalUser,Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "NormalUser,Admin")]
        [HttpPost]
        public  IActionResult Add(AddMealDTO mealDTO)
        {
            Meal meal = MealFromAddMealDTO(mealDTO);

            _mealLogic.Create(meal);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "NormalUser,Admin")]
        public IActionResult Update(string ID)
        {
            Meal meal = _mealLogic.Read(ID);
            UpdateMealDTO mealDTO = UpdateMealDTOFromMeal(meal);

            return View(mealDTO);
        }

        [Authorize(Roles = "NormalUser,Admin")]
        [HttpPost]
        public IActionResult Update(UpdateMealDTO mealDTO)
        {
            Meal meal = MealFromUpdateMealDTO(mealDTO);

            _mealLogic.Update(meal);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "NormalUser,Admin")]
        [HttpGet]
        public IActionResult Delete(string ID)
        {
            _mealLogic.Delete(ID);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Meal MealFromAddMealDTO(AddMealDTO mealDTO)
        {
            Meal meal = new Meal();
            meal.Name = mealDTO.Name;
            meal.Description = mealDTO.Description;
            meal.ConsumptionDate = mealDTO.ConsumptionDate;
            meal.MealType = mealDTO.MealType;
            meal.ImageUrl = mealDTO.ImageUrl;
            meal.Recipe = new Recipe();
            meal.Recipe.MealId = meal.Id;
            meal.Recipe.Name = mealDTO.RecipeName;
            meal.Recipe.Description = mealDTO.RecipeDescription;

            return meal;
        }
        private UpdateMealDTO UpdateMealDTOFromMeal(Meal meal)
        {
            UpdateMealDTO mealDTO = new UpdateMealDTO();
            mealDTO.Id = meal.Id;
            mealDTO.Name = meal.Name;
            mealDTO.Description = meal.Description;
            mealDTO.ConsumptionDate = meal.ConsumptionDate;
            mealDTO.MealType = meal.MealType;
            mealDTO.ImageUrl = meal.ImageUrl;
            mealDTO.RecipeName = meal.Recipe.Name;
            mealDTO.RecipeDescription = meal.Recipe.Description;

            return mealDTO;
        }
        private Meal MealFromUpdateMealDTO(UpdateMealDTO mealDTO)
        {
            Meal meal = _mealLogic.Read(mealDTO.Id);
            meal.Name = mealDTO.Name;
            meal.Description = mealDTO.Description;
            meal.ConsumptionDate = mealDTO.ConsumptionDate;
            meal.MealType = mealDTO.MealType;
            meal.ImageUrl = mealDTO.ImageUrl;
            meal.Recipe.Name = mealDTO.RecipeName;
            meal.Recipe.Description = mealDTO.RecipeDescription;

            return meal;
        }
    }
}