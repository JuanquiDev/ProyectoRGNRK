using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using RGNRK.Data;

namespace RGNRK.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(ILogger<IndexModel> logger, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToPage("/IndexLoggedIn");
            }

            return Page();
        }
    }
}