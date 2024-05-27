using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using RGNRK.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RGNRK.Pages
{
    public class IndexLoggedInModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RGNRKContext _context;

        public IndexLoggedInModel(UserManager<IdentityUser> userManager, RGNRKContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public Users UserProfile { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            UserProfile = await _context.Users
                                        //.Include(u => u.Reservas)
                                        .FirstOrDefaultAsync(u => u.IdentityUserId == user.Id);
        }
    }
}