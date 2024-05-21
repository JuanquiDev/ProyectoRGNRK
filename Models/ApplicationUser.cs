using Microsoft.AspNetCore.Identity;

namespace RGNRK.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Category UserCategory { get; set; }
    }

    public enum Category
    {
        Basic,
        Standard,
        Advanced
    }
}