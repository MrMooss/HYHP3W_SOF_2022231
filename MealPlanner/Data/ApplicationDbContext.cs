using Common;
using MealPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext<SiteUser>
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<SiteUser> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "NormalUser", NormalizedName = "NORMALUSER" }
                );

            PasswordHasher<SiteUser> ph = new PasswordHasher<SiteUser>();
            string ID = Guid.NewGuid().ToString();
            SiteUser testUser = new SiteUser
            {
                Id = ID,
                Email = "test@test.com",
                EmailConfirmed = true,
                UserName = "testuser",
                NormalizedUserName = "TESTUSER",
                ProfilePictureUrl = $"{ID}_testuser"
            };
            testUser.PasswordHash = ph.HashPassword(testUser, "password");
            builder.Entity<SiteUser>().HasData(testUser);

            string mealId = Guid.NewGuid().ToString();
            Meal meal1 = new Meal
            {
                Id = mealId,
                Name = "Test Meal",
                Description = "Nagyon teszt",
                ImageUrl = $"{mealId}_Test Meal",
                ConsumptionDate = DateTime.Parse("06/01/2023 07:22:16"),
                MealType = MealType.Breakfast
            };

            Recipe recipeForMeal1 = new Recipe
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test Recipe",
                Description = "Teszt recept leírása",
                MealId = meal1.Id
            };
            builder.Entity<Meal>().HasData(meal1);
            builder.Entity<Recipe>().HasData(recipeForMeal1);

            builder.Entity<Meal>()
                .HasOne(t => t.Recipe)
                .WithOne()
                .HasForeignKey<Recipe>(t => t.MealId)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(builder);
        }
    }
}