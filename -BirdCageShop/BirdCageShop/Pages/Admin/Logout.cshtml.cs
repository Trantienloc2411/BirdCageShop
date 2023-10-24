using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdCageShop.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnPost()
        {
            // Perform logout actions (e.g., sign out the user)
            // Example: HttpContext.SignOutAsync();
            HttpContext.Session.Clear();

            return RedirectToPage("../Index"); // Redirect to the home page after logout
        }
    }
}
