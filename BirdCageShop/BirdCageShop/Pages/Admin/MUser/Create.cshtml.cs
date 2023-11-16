using BirdCageShop.wwwroot.UploadService;
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
        private readonly IUploadService _uploadService;

        public CreateModel(IUserRepository userRepository, IUploadService uploadService)
        {
            _userRepo = userRepository;
            this._uploadService = uploadService;
        }

        public IActionResult OnGet()
        {
            User = new BusinessObjects.Models.User();

            var listRoles = _userRepo.GetUserRole();
            ViewData["RoleId"] = new SelectList(listRoles, "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public string UserImg { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile UserImg)
        {
            if (UserImg != null)
            {
                User.UserImg = await _uploadService.UploadFileAsync(UserImg);
            }

            _userRepo.Add(User);

            return RedirectToPage("./Index");
        }
    }
}
