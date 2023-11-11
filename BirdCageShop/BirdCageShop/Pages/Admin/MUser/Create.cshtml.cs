using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MUser
{
    public class CreateModel : PageModel
    {
        private readonly IUserRepository _userRepo;

        public CreateModel(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public IActionResult OnGet()
        {
            User = new BusinessObjects.Models.User();

            var listRoles = _userRepo.GetUserRole();
            TempData["RoleId"] = new SelectList(listRoles, "RoleId", "RoleName", User.RoleId);
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userRepo.Add(User);

            return RedirectToPage("./Index");
        }
    }
}
