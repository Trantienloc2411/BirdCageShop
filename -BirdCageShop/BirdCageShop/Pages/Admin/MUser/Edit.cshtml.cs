using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MUser
{
    public class EditModel : PageModel
    {
        private readonly IUserRepository _userRepo;

        public EditModel(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = _userRepo.GetUserById(id);

            if (User == null)
            {
                return NotFound();
            }
            var listRoles = _userRepo.GetUserRole();
            TempData["RoleId"] = new SelectList(listRoles, "RoleId", "RoleName", User.RoleId);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _userRepo.Update(User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}
