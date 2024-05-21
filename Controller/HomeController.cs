using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToPage("/PersonalPage");
        }

        return View();
    }
}