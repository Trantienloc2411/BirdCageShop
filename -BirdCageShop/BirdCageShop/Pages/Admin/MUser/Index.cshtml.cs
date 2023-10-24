using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MUser
{
    public class IndexModel : PageModel
    {
        private readonly UserRepository _userRepo;

        public IndexModel()
        {
            _userRepo = new UserRepository();
        }

        public IList<User> User { get; set; }

        public IActionResult OnGet()
        {
            User = _userRepo.GetAllUser().ToList();
            return Page();
        }

        public IActionResult OnPostSearch()
        {
            string search = Request.Form["SearchString"];
            if (search != null)
            {
                User = _userRepo.GetListUserByName(search);
                return Page();
            }
            return Page();
        }
    }
}
