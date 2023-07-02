using Common.BlobLogic;
using Common.DTOs;
using MealPlanner.Interfaces;
using MealPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        BlobLogic bl = new BlobLogic();
        public HomeController(ILogger<HomeController> logger, UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager, IMealLogic mealLogic, IRecipeLogic recipeLogic)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _mealLogic = mealLogic;
            _recipeLogic = recipeLogic;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View(new List<Meal>());
            else if (await _userManager.IsInRoleAsync(user, "Admin"))
                return View(_mealLogic.ReadAll());
            else
                return View(_mealLogic.ReadAll().Where(t => t.OwnerId == user.Id));
            
        }

        [Authorize(Roles = "NormalUser,Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "NormalUser,Admin")]
        [HttpPost]
        public  async Task<IActionResult> Add([FromForm]AddMealDTO mealDTO, [FromForm] IFormFile image)
        {
            ModelState.Remove("ImageUrl");
            if (!ModelState.IsValid)
            {
                return View(mealDTO);
            }
            var url = await bl.Upload(image);
            mealDTO.ImageUrl = url;
            Meal meal = MealFromAddMealDTO(mealDTO);
            var user = await _userManager.GetUserAsync(User);
            meal.Owner = user;
            try
            {
                _mealLogic.Create(meal);
            }
            catch (Exception e)
            {
                return View("Error", e.Message);
            }
            

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "NormalUser,Admin")]
        public IActionResult Update(string ID)
        {
            Meal meal = _mealLogic.Read(ID);
            if(meal == null)
            {
                return View("Error", "No meal found!");
            }
            UpdateMealDTO mealDTO = UpdateMealDTOFromMeal(meal);

            return View(mealDTO);
        }

        [Authorize(Roles = "NormalUser,Admin")]
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateMealDTO mealDTO, [FromForm] IFormFile image)
        {
            ModelState.Remove("image");
            if (!ModelState.IsValid)
            {
                return View(mealDTO);
            }
            if(image != null)
            {
                await bl.Delete(mealDTO.ImageUrl);
                var url = await bl.Upload(image);
                mealDTO.ImageUrl = url;
            }
            Meal meal = MealFromUpdateMealDTO(mealDTO);

            try
            {
                _mealLogic.Update(meal);
            }
            catch (Exception e)
            {
                return View("Error", e.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "NormalUser,Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(string ID)
        {
            Meal meal = _mealLogic.Read(ID);
            if(meal == null)
            {
                return View("Error", "No meal found!");
            }
            await bl.Delete(meal.ImageUrl);
            _mealLogic.Delete(ID);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateProfilePic()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfilePic([FromForm]IFormFile image)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Email == this.User.Identity.Name);
            await bl.Delete(user.ProfilePictureUrl);
            var url = await bl.Upload(image);
            user.ProfilePictureUrl = url;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string message)
        {
            return View(message);
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