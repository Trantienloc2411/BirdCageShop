using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Login
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepo;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IndexModel()
        {
            _userRepo = new UserRepository();
        }


        public IActionResult OnPost()
        {
            var user = _userRepo.checkUserLogin(Email, Password);
            if (user != null)
            {
                if (user.RoleId == 1)
                {
                    HttpContext.Session.SetString("LoggedInUser", "User");
                    HttpContext.Session.SetString("userName", user.UserName);
                    return RedirectToPage("../Index");
                }
                else if (user.RoleId == 2)
                {
                    HttpContext.Session.SetString("LoggedInUser", "Adminstrator");
                    return RedirectToPage("../Admin/MProduct/Index");
                }
                else if (user.RoleId == 3)
                {
                    HttpContext.Session.SetString("LoggedInUser", "Shopkeeper");
                    return RedirectToPage("../Index");
                }
                else
                {
                    TempData["errorMessage"] = "You are not allowed to do this function!";
                    return Page();

                }

            }
            else
            {
                TempData["errorMessage"] = "Wrong email or password! Try Again";
                return Page();
            }

        }
    }
}