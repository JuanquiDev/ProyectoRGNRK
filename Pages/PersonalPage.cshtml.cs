using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using RGNRK.Models;

public class PersonalPageModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;

    public PersonalPageModel(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public ApplicationUser User { get; set; }

    public async Task OnGetAsync()
    {
        User = await _userManager.GetUserAsync(HttpContext.User);
    }
}