using Microsoft.AspNetCore.Identity;

namespace MealPlanner.Models
{
    public class SiteUser : IdentityUser
    {
        public string ProfilePictureUrl { get; set; }
    }
}
