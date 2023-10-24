using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MUser
{
    public class DetailsModel : PageModel
    {
        private readonly IUserRepository _userRepo;

        public DetailsModel(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public User User { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = _userRepo.GetUserById(id);
            ViewData["RoleId"] = new SelectList(_userRepo.GetUserRole(), "CategoryId", "CategoryId");

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
