using MealPlanner.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
            builder.Entity<Meal>()
                .HasOne(t => t.Recipe)
                .WithOne(t => t.Meal)
                .HasForeignKey<Recipe>(t => t.MealId);
            base.OnModelCreating(builder);
        }
    }
}