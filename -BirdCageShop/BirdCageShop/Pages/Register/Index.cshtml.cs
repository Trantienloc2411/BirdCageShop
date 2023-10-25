using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Register
{
	public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepo;

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string UserName { get; set; }

        public string ErrorMessage { get; set; }

        public IndexModel()
        {
            _userRepo = new UserRepository();
        }
        public IActionResult OnPost()
        {
            User user = new User();
            user.UserName = this.UserName;
            user.UserPassword = this.Password;
            user.Email = this.Email;
            user.RoleId = 1;
            var isEmailExisted = _userRepo.isEmailexisted(this.UserName);
            if (isEmailExisted)
            {
                TempData["errorMessage"] = "This email is registered! Try another one.";
                return Page();
            }
            else
            {

                _userRepo.Add(user);

                TempData["successMessage"] = "Register successfully!";
                return Page();
            }


        }
    }
}
