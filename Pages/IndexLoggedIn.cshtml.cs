using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using RGNRK.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RGNRK.Pages
{
    public class IndexLoggedInModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly RGNRKContext _context;

        public IndexLoggedInModel(UserManager<User> userManager, RGNRKContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public User UserProfile { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            UserProfile = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.FirstName = UserProfile.FirstName;
            user.LastName = UserProfile.LastName;
            user.Height = UserProfile.Height;
            user.Weight = UserProfile.Weight;
            user.UserCategory = UserProfile.UserCategory;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
