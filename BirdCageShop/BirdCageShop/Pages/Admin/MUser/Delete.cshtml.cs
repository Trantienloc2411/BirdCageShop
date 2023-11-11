using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MUser
{
    public class DeleteModel : PageModel
    {
        private readonly IUserRepository _userRepo;

        public DeleteModel(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
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
            return Page();
        }

        public IActionResult OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = _userRepo.GetUserById(id);

            if (User != null)
            {
                _userRepo.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
